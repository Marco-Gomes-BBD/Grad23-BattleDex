namespace Grad23_BattleDex.Topics
{
  public class LSystem
  {
    private readonly Dictionary<char, string[]> rules;
    private readonly string axiom;
    private readonly Random random;

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