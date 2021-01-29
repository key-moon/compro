using System.Net;
using System.Net.Http;
using System.Text.Json;

static var client = new HttpClient(new HttpClientHandler(){
  AutomaticDecompression = DecompressionMethods.GZip
});

static async Task<string> FetchStringAsync(string url)
{
    WriteLine($"fetching {url} ...");
    var sourceCode = await client.GetStringAsync(url);
    await Task.Delay(1000);
    return sourceCode;
}

static var extensionList = new[]
{
  ("Awk", "awk"),
  ("C#", "cs"),
  ("C++", "cpp"),
  ("Bash", "sh"),
  ("Brainfuck", "bf"),
  ("COBOL", "cobol"),
  ("Clojure", "clj"),
  ("Lisp", "lisp"),
  ("Crystal", "cr"),
  ("Fortran", "f"),
  ("Go", "go"),
  ("Haskell", "hs"),
  ("JavaScript", "js"),
  ("Java", "java"),
  ("Julia", "jl"),
  ("Kotlin", "kt"),
  ("MoonScript", "moon"),
  ("Nim", "nim"),
  ("OCaml", "ml"),
  ("Objective", "m"),
  ("Octave", "m"),
  ("PHP", "php"),
  ("Pascal", "pas"),
  ("Perl", "pl"),
  ("Python", "py"),
  ("Ruby", "rb"),
  ("Scala", "scala"),
  ("Scheme", "ss"),
  ("Sed", "sed"),
  ("Swift", "swift"),
  ("Text", "txt"),
  ("TypeScript", "ts"),
  ("Unlambda", "unl"),
  ("Basic", "vb"),
  ("ML", "sml"),
  ("F#", "fs"),
  ("C", "c"),
  ("D", "d"),
  ("", "unknown")
};

static var commentAffixList = new[]
{
  ("Awk", ("#", "")),
  ("C#", ("//", "")),
  ("C++", ("//", "")),
  ("Bash", ("#", "")),
  ("Brainfuck", ("#", "")),
  ("COBOL", ("*", "")),
  ("Clojure", (";", "")),
  ("Lisp", (";", "")),
  ("Crystal", ("#", "")),
  ("Fortran", ("*", "")),
  ("Go", ("//", "")),
  ("Haskell", ("--", "")),
  ("JavaScript", ("//", "")),
  ("Java", ("//", "")),
  ("Julia", ("#", "")),
  ("Kotlin", ("//", "")),
  ("MoonScript", ("--", "")),
  ("Nim", ("#", "")),
  ("OCaml", ("(*", "*)")),
  ("Objective", ("//", "")),
  ("Octave", ("%{", "%}")),
  ("PHP", ("<!--", "--?")),
  ("Pascal", ("//", "")),
  ("Perl", ("#", "")),
  ("Python", ("#", "")),
  ("Ruby", ("#", "")),
  ("Scala", ("//", "")),
  ("Scheme", (";", "")),
  ("Sed", ("//","")),           // inaccurate
  ("Swift", ("//", "")),
  ("Text", ("//","")),          // inaccurate
  ("TypeScript", ("//", "")),
  ("Unlambda", ("#", "")),
  ("Basic", ("'", "")),
  ("ML", ("(*", "*)")),
  ("F#", ("//", "")),
  ("C", ("//","")),
  ("D", ("//", "")),
  ("", ("#", ""))
};

static string GetExtension(string language)
{
  foreach (var (lang, extension) in extensionList)
  {
    if (language.Contains(lang)) return extension;
  }
  throw new Exception();
}

static string CommentOutLine(string language, string line)
{
  foreach (var (lang, (suffix, prefix)) in commentAffixList)
  {
    if (language.Contains(lang)) return $"{suffix}{line}{prefix}";
  }
  throw new Exception();
}

