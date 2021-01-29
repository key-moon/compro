#r "nuget: AngleSharp, 0.14.0"
#load "../variable.csx"
#load "../crawler.csx"

using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using AngleSharp;
using AngleSharp.Html.Parser;

public class APIResult{
  public long id { get; set; }
  public long epoch_second { get; set; }
  public string problem_id { get; set; }
  public string contest_id { get; set; }
  public string user_id { get; set; }
  public string language { get; set; }
  public double point { get; set; }
  public long length { get; set; }
  public string result { get; set; }
  public long? execution_time { get; set; }
}

class AtCoderSubmission : Submission
{
  private APIResult Result { get; set; }
  public override string SiteIdentifier => "atcoder";
  public override string ProblemIdentifier => $"{Result.contest_id}/{Result.problem_id}";
  public override string SubmissionIdentifier => Result.id.ToString();
  public override bool Accepted => Result.result == "AC";
  public override string Language => Result.language;
  public override DateTime Submitted => DateTimeOffset.FromUnixTimeSeconds(Result.epoch_second).DateTime;
  public override string SubmissionUrl => $"https://atcoder.jp/contests/{Result.contest_id}/submissions/{Result.id}";

  

  public AtCoderSubmission(APIResult result)
  {
    Result = result;
  }

  public override async Task<string> GetSourceCode()
  {
    var parser = new HtmlParser();
    var submissionHtml = await FetchStringAsync(SubmissionUrl);
    var submissionDocument = parser.ParseDocument(submissionHtml);
    var sourceCode = submissionDocument.GetElementById("submission-code").TextContent;
    return sourceCode;
  }
}

async Task<AtCoderSubmission[]> GetAtCoderSubmissionsAsync(){
  var apiUrl = $"https://kenkoooo.com/atcoder/atcoder-api/results?user={AtCoderUserName}";
  var resultsJson = await FetchStringAsync(apiUrl);
  var results = JsonSerializer.Deserialize<APIResult[]>(resultsJson);
  return results.Select(x => new AtCoderSubmission(x)).ToArray();
}
