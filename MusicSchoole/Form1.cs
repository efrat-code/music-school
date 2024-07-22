using MusicSchoole.Model;
using static MusicSchoole.Service.MusicSchoolServic;


namespace MusicSchoole
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateXmlIfNotExists();
            //InsertClassRoom("gitar gazz");
            //AddTeacher("gitar gazz", "enosh");
            //AddStudent("gitar gazz", "shmuel", "");
            Instrument instrument = new Instrument("gitar");
            Student student1 = new Student("moshe", instrument);
            //UpdateInstrument("shmuel", student.instrument);
            ReplaceStudent("shmuel",student1);
        }
    }
}
