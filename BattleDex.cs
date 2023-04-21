using Grad23_BattleDex.Database;
using Grad23_BattleDex.services;
using Grad23_BattleDex.SG;
using Grad23_BattleDex.Topics;
using TextBox = System.Windows.Forms.TextBox;

namespace Grad23_BattleDex
{
    public partial class frmBattle : Form
    {
        private BattleDexTopic topicGenerator;
        private string topic;
        private int slideCount;
        private int time;
        List<string> slides;
        int currentSlide = 0;

        private const string battlePath = "Resources\\battledex\\";
        private const string rulesPath = "Resources\\rules.json";
        private const string tagsRelativeBattlePath = "tags.json";

        public frmBattle()
        {
            InitializeComponent();

            topicGenerator = new(rulesPath);
            topic = string.Empty;

            DatabaseFunctions.InsertImages(battlePath + tagsRelativeBattlePath);

            slideCount = (int)nudSlides.Value;
            slides = new();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<string> exportSlides = slides.Select(path => battlePath + path).ToList();
            DeckGenerator.CreatePresentation("Resources\\template.pptx", "presentation.pptx", topic, exportSlides);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string[] tags = TopicParser.Parse(topic);
            slides = SlideGenerator.Generate(tags.ToList(), slideCount);

            ChangeSlide(0);
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            string newTopic = topicGenerator.CreateTopic(5);
            txtTopic.Text = newTopic;
        }

        private void txtTopic_TextChanged(object sender, EventArgs e)
        {
            TextBox txtSender = (TextBox)sender;
            topic = txtSender.Text;
        }

        private void nudSlides_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudSender = (NumericUpDown)sender;
            slideCount = (int)nudSender.Value;
        }

        private void nudTime_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudSender = (NumericUpDown)sender;
            time = (int)nudSender.Value;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            ChangeSlide(currentSlide - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ChangeSlide(currentSlide + 1);
        }

        private void ChangeSlide(int slide)
        {
            btnPrev.Enabled = slide > 0;
            btnNext.Enabled = slide < slides.Count - 1;

            if (slide > -1 && slide < slides.Count)
            {
                pbBattle.Image = Image.FromFile(battlePath + slides[slide]);
            }
            currentSlide = slide;
        }
    }

}
