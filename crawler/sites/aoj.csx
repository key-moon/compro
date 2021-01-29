#load "../variable.csx"
#load "../crawler.csx"

using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;

class AOJSubmissionRecord{
  public int JudgeId { get; set; }
  public int JudgeType { get; set; }
  public string UserId { get; set; }
  public string ProblemId { get; set; }
  public long SubmissionDate { get; set; }
  public string Language { get; set; }
  public int Status { get; set; }
  public long CpuTime { get; set; }
  public long Memory { get; set; }
  public long CodeSize { get; set; }
  public string Accuracy { get; set; }
  public long JudgeDate { get; set; }
  public int Score { get; set; }
  public string ProblemTitle { get; set; }
  public string Token { get; set; }
}

class Review{
  public int JudgeId { get; set; }
  public string UserId { get; set; }
  public string ProblemId { get; set; }
  public string Language { get; set; }
  public long CpuTime { get; set; }
  public long Memory { get; set; }
  public long SubmissionDate { get; set; }
  public string Policy { get; set; }
  public string SourceCode { get; set; }
}

class AOJSubmission : Submission
{
  private AOJSubmissionRecord Record { get; set; }
  public override string SiteIdentifier => "aoj";
  public override string ProblemIdentifier => Record.ProblemId;
  public override string SubmissionIdentifier => Record.JudgeId.ToString();
  public override bool Accepted => Record.Status == 4;
  public override string Language => Record.Language;
  public override DateTime Submitted => DateTimeOffset.FromUnixTimeMilliseconds(Record.SubmissionDate).DateTime;
  public override string SubmissionUrl => $"https://onlinejudge.u-aizu.ac.jp/status/users/{Record.UserId}/submissions/1/{Record.ProblemId}/judge/{Record.JudgeId}/{Record.Language}";

  public AOJSubmission(AOJSubmissionRecord record)
  {
    Record = record;
  }

  public override async Task<string> GetSourceCode()
  {
    var apiUrl = $"https://judgeapi.u-aizu.ac.jp/reviews/{Record.JudgeId}";
    var reviewJson = await FetchStringAsync(apiUrl);
    var sourceCode = JsonSerializer.Deserialize<Review>(
      reviewJson,
      new JsonSerializerOptions(){
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
      }
    ).SourceCode;
    return sourceCode;
  }
}

async Task<AOJSubmission[]> GetAOJSubmissionsAsync(){
  var apiUrl = $"https://judgeapi.u-aizu.ac.jp/submission_records/users/{AOJUserName}?page=0&size=100000";
  var resultsJson = await FetchStringAsync(apiUrl);
  var results = JsonSerializer.Deserialize<AOJSubmissionRecord[]>(
    resultsJson,
    new JsonSerializerOptions(){
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    }
  );
  return results.Select(x => new AOJSubmission(x)).ToArray();
}
