#load "git.csx"
#load "util.csx"

abstract class Submission
{
  public abstract string SiteIdentifier { get; }
  public abstract string ProblemIdentifier { get; }
  public abstract string SubmissionIdentifier { get; }
  public abstract bool Accepted { get; }
  public abstract string Language { get; }
  public abstract DateTime Submitted { get; }
  public abstract string SubmissionUrl { get; }
  private string _SourceCode = null;
  public string SourceCode
  {
    get
    {
      try {
        return _SourceCode = _SourceCode ?? GetSourceCode().Result;
      }
      catch (AggregateException e) {
        throw e.InnerException;
      }
    }
  }

  public abstract Task<string> GetSourceCode();
}

[System.Serializable]
public class IgnoreException : System.Exception
{
    public IgnoreException() { }
    public IgnoreException(string message) : base(message) { }
    public IgnoreException(string message, System.Exception inner) : base(message, inner) { }
    protected IgnoreException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

static var exists = new Dictionary<string, HashSet<string>>();
static bool Exist(string siteIdentifier, string submissionIdentifier)
{
  if (!exists.ContainsKey(siteIdentifier)) 
  {
        System.IO.Directory.CreateDirectory(siteIdentifier);
    exists[siteIdentifier] = 
        Directory.GetFiles(siteIdentifier, "*", SearchOption.AllDirectories)
        .Select(Path.GetFileName)
        .Select(x => x.Split('.').First().Trim())
        .ToHashSet();
  }
  return exists[siteIdentifier].Contains(submissionIdentifier);
}

static string GetDirectory(this Submission submission) => $"{submission.SiteIdentifier}/{submission.ProblemIdentifier}";
static string GetFileName(this Submission submission) => $"{submission.SubmissionIdentifier}.{GetExtension(submission.Language)}";


static void Write(Submission submission)
{
  var siteIdentifier = submission.SiteIdentifier;
  var problemIdentifier = submission.ProblemIdentifier;
  var submissionIdentifier = submission.SubmissionIdentifier;
  if (Exist(siteIdentifier, submissionIdentifier)) return;

  var path = $"{submission.GetDirectory()}/{submission.GetFileName()}";
  var header = CommentOutLine(submission.Language, $" detail: {submission.SubmissionUrl} ").Trim();
  var content = $"{header}\n{submission.SourceCode}";
  WriteSubmissions(path, content, submission.Submitted);
}
