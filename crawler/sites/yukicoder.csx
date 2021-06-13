#r "nuget: AngleSharp, 0.14.0"
#load "../variable.csx"
#load "../crawler.csx"

using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using AngleSharp;
using AngleSharp.Html.Parser;

class YukicoderSubmissionRecord{
  public string SubmissionId { get; set; }
  public DateTime SubmissionDate { get; set; }
  public string UserId { get; set; }
  public string ProblemTitle { get; set; }
  public string ProblemNo { get; set; }
  public string Language { get; set; }
  public string Status { get; set; }
  public long CpuTime { get; set; }
  public long CodeSize { get; set; }
}

class YukicoderSubmission : Submission
{
  private YukicoderSubmissionRecord Record { get; set; }
  public override string SiteIdentifier => "yukicoder";
  public override string ProblemIdentifier => Record.ProblemNo;
  public override string SubmissionIdentifier => Record.SubmissionId;
  public override bool Accepted => Record.Status == "AC";
  public override string Language => Record.Language;
  public override DateTime Submitted => Record.SubmissionDate;
  public override string SubmissionUrl => $"https://yukicoder.me/submissions/{Record.SubmissionId}";

  public YukicoderSubmission(YukicoderSubmissionRecord record)
  {
    Record = record;
  }

  public override async Task<string> GetSourceCode()
  {
    var apiUrl = $"https://yukicoder.me/submissions/{Record.SubmissionId}/source";
    var sourceCode = await FetchStringAsync(apiUrl);
    return sourceCode;
  }
}

async Task<YukicoderSubmission[]> GetYukicoderSubmissionsAsync()
{
  List<YukicoderSubmission> list = new List<YukicoderSubmission>();
  int i = 1;
  while (true)
  {
    var apiUrl = $"https://yukicoder.me/users/{YukicoderUserID}/submissions?page={i}&status=AC";
    var resultsHtml = await FetchStringAsync(apiUrl);

    var parser = new HtmlParser();
    var document = parser.ParseDocument(resultsHtml);
    var children = document.GetElementsByTagName("tbody")[0].Children;
    if (document.GetElementsByTagName("tbody")[0].ChildElementCount == 0) break;
    foreach (var row in document.GetElementsByTagName("tbody")[0].Children)
    {
      var record = new YukicoderSubmissionRecord();
      var submissionIdNode = row.Children[0];
      record.SubmissionId = submissionIdNode.TextContent;

      var dateNode = row.Children[1];
      record.SubmissionDate = DateTime.Parse(dateNode.TextContent + "+09").ToUniversalTime();
      
      var userNode = row.Children[3];
      var userUrl = userNode.Children[0].GetAttribute("href");
      record.UserId = userUrl.Split('/').Last().Trim();
      
      var titleNode = row.Children[4];
      record.ProblemTitle = titleNode.TextContent;
      var problemUrl = titleNode.Children[0].GetAttribute("href");
      record.ProblemNo = problemUrl.Split('/').Last().Trim();
      
      var languageNode = row.Children[5];
      record.Language = languageNode.TextContent.Trim();
      
      var statusNode = row.Children[6];
      record.Status = statusNode.TextContent.Trim();

      var cpuTimeNode = row.Children[7];
      long cpuTime;
      long.TryParse(Regex.Match(cpuTimeNode.TextContent.Trim(), @"\d+").Value, out cpuTime);
      record.CpuTime = cpuTime;

      var codeSizeNode = row.Children[8];
      long codeSize;
      long.TryParse(Regex.Match(codeSizeNode.TextContent.Trim(), @"\d+").Value, out codeSize);
      record.CodeSize = codeSize;

      list.Add(new YukicoderSubmission(record));
    }
    i++;
  }
  return list.ToArray();
}
