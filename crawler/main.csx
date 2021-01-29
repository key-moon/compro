#!/usr/bin/env dotnet-script
#load "git.csx"
#load "crawler.csx"
#load "ignored.csx"
#load "sites/atcoder.csx"
#load "sites/aoj.csx"
#load "sites/codeforces.csx"
#load "sites/yukicoder.csx"

InitGit();
var submissions = new Submission[][] {
  await GetCodeforcesSubmissionsAsync(),
  await GetAtCoderSubmissionsAsync(),
  await GetAOJSubmissionsAsync(),
  await GetYukicoderSubmissionsAsync()
}.SelectMany(x => x).Where(x => x.Accepted).OrderBy(x => x.Submitted).ToArray();
Dictionary<string, Ignored> ignored = new Dictionary<string, Ignored>();
foreach (var submission in submissions) {
  if (!ignored.ContainsKey(submission.SiteIdentifier)) {
    ignored[submission.SiteIdentifier] = new Ignored(submission.SiteIdentifier);
  }
  if (Exist(submission.SiteIdentifier, submission.SubmissionIdentifier) ||
    ignored[submission.SiteIdentifier].Contains(submission.GetFileName())) continue;
  bool shouldIgnore = false;
  try {  
    var firstLine = submission.SourceCode.Split('\n', 2).First();
    const string ignoreToken = "ignore";
    if (firstLine.Contains(ignoreToken) && firstLine.Length <= ignoreToken.Length + 8) throw new IgnoreException("ignore token found.");
  }
  catch(IgnoreException e) {
    Console.WriteLine($"ignored. reason: {e.Message}");
    shouldIgnore = true;
  }
  catch(Exception e) {
    Console.WriteLine($"skipped. reason: {e.Message}");
    continue;
  }

  if (shouldIgnore) {
    ignored[submission.SiteIdentifier].Add(submission.GetFileName());
    continue;
  }
  Write(submission);
}
ApplyChange();
