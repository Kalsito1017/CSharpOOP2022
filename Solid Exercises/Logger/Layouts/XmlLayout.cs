
namespace Logger.Layouts
{
    public class XmlLayout : Layout
    {
        //Xml Format
        private const string XmlLayoutFormat = @"<log>
      </date>{0}</date>
      <level>{1}</level>
      <message>{2}</message>
</log>";
        public XmlLayout()
            :base(XmlLayoutFormat)
        {

        }

        
    }
}
