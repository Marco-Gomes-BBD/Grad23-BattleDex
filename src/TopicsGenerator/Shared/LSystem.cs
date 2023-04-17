namespace Grad23_BattleDex.src.TopicsGenerator.Shared
{
  public class LSystem
  {
    private Dictionary<char, string[]> rules;
    private string axiom;
    private Random random;

    public LSystem(string axiom, Dictionary<char, string[]> rules)
    {
      this.axiom = axiom;
      this.rules = rules;
      this.random = new Random();
    }

    public LSystem(string axiom, Dictionary<char, string[]> rules, int seed)
    {
      this.axiom = axiom;
      this.rules = rules;
      this.random = new Random(seed);
    }

    public string Generate(int iterations)
    {
      string current = axiom;
      for (int i = 0; i < iterations; i++)
      {
        string next = "";
        foreach (char c in current)
        {
          if (rules.ContainsKey(c))
          {
            string[] options = rules[c];
            string replacement = options[random.Next(0, options.Length)];
            next += replacement;
          }
          else
          {
            next += c;
          }
        }
        current = next;
      }
      return current;
    }
  }
}