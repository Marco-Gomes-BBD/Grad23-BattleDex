using System.Text.Json;

namespace Grad23_BattleDex.Topics
{
  public class RuleSet
  {
    public char rule {get; set;}
    public string[]? data {get; set;}

    public bool start {get; set;}
  }
  
  public class RulesLoader
  {
    private string axiom;
    private string filePath;

    public RulesLoader(string filePath)
    {
      this.axiom = "S";
      this.filePath = filePath;
    }

    public Dictionary<char, string[]> LoadRuleSet()
    {
      List<RuleSet>? jsonData = new List<RuleSet>();
      using (StreamReader r = new StreamReader(filePath))
      {
        string json = r.ReadToEnd();
        jsonData = JsonSerializer.Deserialize<List<RuleSet>>(json);
      }
      Dictionary<char, string[]> rules = new Dictionary<char, string[]>();
      foreach (RuleSet set in jsonData!)
      {
        if(set.start){
          this.axiom = set.rule.ToString();
        }
        rules[set.rule] = set.data!;
      }
      return rules;
    }

    public string GetAxiom()
    {
      return axiom;
    }
  }
}