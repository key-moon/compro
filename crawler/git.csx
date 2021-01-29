#load "variable.csx"

static void Git(string arg)
{
  var proc = Process.Start("git", arg);
  proc.WaitForExit();
}

static void InitGit()
{
  Git($"config user.name {GitUserName}");
  Git($"config user.email {GitEMail}");
  Git($"config commit.gpgsign false");
  Git($"remote set-url origin {GitRemoteURL}");
  Git($"checkout master");
}

static int count = 0;
static void WriteSubmissions(string path, string content, DateTime dateTime)
{ 
  var directory = Path.GetDirectoryName(path);
  if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
  File.WriteAllText(path, content);
  Git("add .");
  Git($@"commit -a -m ""add {path}"" --date=""{dateTime.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'")}""");
  count++;
}

static void ApplyChange()
{
  Git($"rebase --committer-date-is-author-date HEAD~{count}");
  Git($"push origin HEAD");
}
