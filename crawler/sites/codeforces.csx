#r "nuget: AngleSharp, 0.14.0"
#load "../variable.csx"
#load "../crawler.csx"

using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using AngleSharp;
using AngleSharp.Html.Parser;

public class CodeforcesSubmissionInfo
{
  public int Id { get; set; } 
  public int ContestId { get; set; } 
  public int CreationTimeSeconds { get; set; } 
  public int RelativeTimeSeconds { get; set; } 
  public ProblemInfo Problem { get; set; } 
  public AuthorInfo Author { get; set; } 
  public string ProgrammingLanguage { get; set; } 
  public string Verdict { get; set; } 
  public string Testset { get; set; } 
  public int PassedTestCount { get; set; } 
  public int TimeConsumedMillis { get; set; } 
  public int MemoryConsumedBytes { get; set; } 

  public class ProblemInfo
  {
    public int ContestId { get; set; } 
    public string Index { get; set; } 
    public string Name { get; set; } 
    public string Type { get; set; } 
    public double Points { get; set; } 
    public int Rating { get; set; } 
    public List<string> Tags { get; set; } 
  }

  public class MemberInfo
  {
    public string Handle { get; set; } 
  }

  public class AuthorInfo
  {
    public int ContestId { get; set; } 
    public List<MemberInfo> Members { get; set; } 
    public string ParticipantType { get; set; } 
    public bool Ghost { get; set; } 
    public int Room { get; set; } 
    public int StartTimeSeconds { get; set; } 
  }
}

public class CodeforcesAPIResult
{
  public string Status { get; set; }
  public CodeforcesSubmissionInfo[] Result { get; set; }
}

class CodeforcesSubmission : Submission
{
  private CodeforcesSubmissionInfo Info { get; set; }
  public override string SiteIdentifier => "codeforces";
  public override string ProblemIdentifier => $"{Info.Problem.ContestId}/{Info.Problem.Index}";
  public override string SubmissionIdentifier => Info.Id.ToString();
  public override bool Accepted => Info.Verdict == "OK";
  public override string Language => Info.ProgrammingLanguage;
  public override DateTime Submitted => DateTimeOffset.FromUnixTimeSeconds(Info.CreationTimeSeconds).DateTime;
  public override string SubmissionUrl => $"https://codeforces.com/{(100000 <= Info.ContestId ? "gym" : "contest")}/{Info.ContestId}/submission/{Info.Id}";

  

  public CodeforcesSubmission(CodeforcesSubmissionInfo info)
  {
    Info = info;
  }

  public override async Task<string> GetSourceCode()
  {
    var submissionHtml = await FetchStringAsync(SubmissionUrl);
    var parser = new HtmlParser();
    var submissionDocument = parser.ParseDocument(submissionHtml);
    if (submissionHtml.Contains("You are not allowed to view the requested page")) throw new IgnoreException("Forbidden page.");
    var sourceCodeElem = submissionDocument.GetElementById("program-source-text");
    if (sourceCodeElem is null) throw new Exception("Failed to extract source.");
    var sourceCode = sourceCodeElem.TextContent;
    return sourceCode;
  }
}

async Task<CodeforcesSubmission[]> GetCodeforcesSubmissionsAsync()
{
  var apiUrl = $"https://codeforces.com/api/user.status?handle={CodeforcesUserName}";
  var resultJson = await FetchStringAsync(apiUrl);
  var result = JsonSerializer.Deserialize<CodeforcesAPIResult>(
    resultJson,
    new JsonSerializerOptions(){
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    }
  );
  return result.Result.Select(x => new CodeforcesSubmission(x)).ToArray();
}
