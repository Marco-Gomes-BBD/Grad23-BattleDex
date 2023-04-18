namespace Grad23_BattleDex.Topics
{
    class BattleDexTopic
  {
    private LSystem lSystem;

    public BattleDexTopic()
    {
      string axiom = "S";
      Dictionary<char, string[]> rules = CreateRules();
      this.lSystem = new LSystem(axiom, rules);
    }

    public BattleDexTopic(string axiom, Dictionary<char, string[]> rules)
    {
      this.lSystem = new LSystem(axiom, rules);
    }

    public BattleDexTopic(int randomSeed)
    {
      string axiom = "S";
      Dictionary<char, string[]> rules = CreateRules();
      this.lSystem = new LSystem(axiom, rules, randomSeed);
    }

    public BattleDexTopic(string axiom, Dictionary<char, string[]> rules, int randomSeed)
    {
      this.lSystem = new LSystem(axiom, rules, randomSeed);
    }
    

    private Dictionary<char, string[]> CreateRules()
    {
      Dictionary<char, string[]> rules = new Dictionary<char, string[]>();
      
      rules['S'] = new string[] { "N P V B P F T" };
      rules['N'] = GetNouns();
      rules['P'] = GetPrepositions(); // Prepositions
      rules['V'] = GetVerbs(); // Verbs
      rules['F'] = GetVerbsTwo(); // Verbs 2
      rules['T'] = GetTopicTail(); // Phrases
      rules['B'] = GetTopicBody(); // Topic Body

      return rules;
    }
    
    private string[] GetPrepositions()
    {
      return new string[] {
        "about",
        "above",
        "across",
        "against",
        "along",
        "among",
        "around",
        "at",
        "before",
        "behind",
        "beside",
        "between",
        "by",
        "down",
        "for",
        "from",
        "in",
        "into",
        "of",
        "on",
        "to",
        "under",
        "upon",
        "with",
        "within"
      };
    }

    private string[] GetNouns()
    {
      return new string [] {
        "importance",
        "import",
        "magnitude",
        "value",
        "moment",
        "benefits",
        "advantage",
        "aid",
        "help",
        "resource",
        "support",
        "impact",
        "effect",
        "influence",
        "consequence",
        "repercussion",
        "importance",
        "significance",
        "role",
        "part",
        "position",
        "participation",
        "capacity",
        "task",
        "purpose"
      }; 
    }
    
    private string[] GetVerbs()
    {
      return new string[] {
        "exercise",
        "meditation",
        "technology",
        "education",
        "art",
        "teamwork",
        "time",
        "social",
        "leadership"
      };
    }
    
    private string[] GetVerbsTwo()
    {
      return new string[] {
        "maintaining",
        "reducing",
        "promoting",
        "fostering",
        "achieving",
        "improving",
        "enhancing",
        "driving"
      };
    }
    
    private string[] GetTopicBody() {
      return new string[] {
        "P society",
        "P culture",
        "media P relationships",
        "P organizations"
      };
    }
    
    private string[] GetTopicTail() {
      return new string [] {
        "a healthy lifestyle",
        "stress and anxiety",
        "personal and professional development",
        "creativity and self-expression",
        "common goals",
        "productivity and efficiency",
        "communication and self-esteem",
        "change and innovation"
      };
    }
    
    public string CreateTopic(int iterations)
    {
      string result = lSystem.Generate(iterations);
      return result;
    }

    public string CreateTopic()
    {
      string result = lSystem.Generate(10);
      return result;
    }
  }

}