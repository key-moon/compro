#load "git.csx"
#load "util.csx"
#load "crawler.csx"

class Ignored {
  public string SiteIdentifier;
  private string IgnoreSettingsFilePath => $"{SiteIdentifier}/.gitignore";
  private HashSet<string> Ignoreds;
  public Ignored(string siteIdentifier) {
    SiteIdentifier = siteIdentifier;
    ReadSettings();
  }
  public bool Add(string submissionIdentifier) {
    if (!Ignoreds.Add(submissionIdentifier)) return false;
    WriteSettings();
    return true;
  }
  public bool Remove(string submissionIdentifier) {
    if (!Ignoreds.Remove(submissionIdentifier)) return false;
    WriteSettings();
    return true;
  }
  private void ReadSettings() => 
    Ignoreds = (File.Exists(IgnoreSettingsFilePath) ? File.ReadAllLines(IgnoreSettingsFilePath) : Enumerable.Empty<string>())
    .Where(x => x != "").ToHashSet();
  private void WriteSettings() {
    File.WriteAllText(IgnoreSettingsFilePath, string.Join("\n", Ignoreds));
    Git("add .");
    Git("commit -m \"update ignore list\"");
  }
  public bool Contains(string submissionIdentifier) {
    return Ignoreds.Contains(submissionIdentifier);
  }
}
