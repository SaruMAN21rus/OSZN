using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

[XmlRoot("Object")]
public class AddressObject
{
    [XmlAttribute("AOGUID")]
    public string AOGUID { get; set; }
    [XmlAttribute("FORMALNAME")]
    public string FORMALNAME { get; set; }
    [XmlAttribute("REGIONCODE")]
    public string REGIONCODE { get; set; }
    [XmlAttribute("AUTOCODE")]
    public char AUTOCODE { get; set; }
    [XmlAttribute("AREACODE")]
    public string AREACODE { get; set; }
    [XmlAttribute("CITYCODE")]
    public string CITYCODE { get; set; }
    [XmlAttribute("CTARCODE")]
    public string CTARCODE { get; set; }
    [XmlAttribute("PLACECODE")]
    public string PLACECODE { get; set; }
    [XmlAttribute("STREETCODE")]
    public string STREETCODE { get; set; }
    [XmlAttribute("EXTRCODE")]
    public string EXTRCODE { get; set; }
    [XmlAttribute("SEXTCODE")]
    public string SEXTCODE { get; set; }
    [XmlAttribute("OFFNAME")]
    public string OFFNAME { get; set; }
    [XmlAttribute("POSTALCODE")]
    public string POSTALCODE { get; set; }
    [XmlAttribute("IFNSFL")]
    public string IFNSFL { get; set; }
    [XmlAttribute("TERRIFNSFL")]
    public string TERRIFNSFL { get; set; }
    [XmlAttribute("IFNSUL")]
    public string IFNSUL { get; set; }
    [XmlAttribute("TERRIFNSUL")]
    public string TERRIFNSUL { get; set; }
    [XmlAttribute("OKATO")]
    public string OKATO { get; set; }
    [XmlAttribute("OKTMO")]
    public string OKTMO { get; set; }
    [XmlAttribute("UPDATEDATE")]
    public System.DateTime UPDATEDATE { get; set; }
    [XmlAttribute("SHORTNAME")]
    public string SHORTNAME { get; set; }
    [XmlAttribute("AOLEVEL")]
    public long AOLEVEL { get; set; }
    [XmlAttribute("PARENTGUID")]
    public string PARENTGUID { get; set; }
    [XmlAttribute("AOID")]
    public string AOID { get; set; }
    [XmlAttribute("PREVID")]
    public string PREVID { get; set; }
    [XmlAttribute("NEXTID")]
    public string NEXTID { get; set; }
    [XmlAttribute("CODE")]
    public string CODE { get; set; }
    [XmlAttribute("PLAINCODE")]
    public string PLAINCODE { get; set; }
    [XmlAttribute("ACTSTATUS")]
    public long ACTSTATUS { get; set; }
    [XmlAttribute("CENTSTATUS")]
    public long CENTSTATUS { get; set; }
    [XmlAttribute("OPERSTATUS")]
    public long OPERSTATUS { get; set; }
    [XmlAttribute("CURRSTATUS")]
    public long CURRSTATUS { get; set; }
    [XmlAttribute("STARTDATE")]
    public System.DateTime STARTDATE { get; set; }
    [XmlAttribute("ENDDATE")]
    public System.DateTime ENDDATE { get; set; }
    [XmlAttribute("NORMDOC")]
    public string NORMDOC { get; set; }
    [XmlAttribute("LIVESTATUS")]
    public sbyte LIVESTATUS { get; set; }

    public AddressObject() { }

    public AddressObject(string xml)
    {
        LoadXml(xml);
    }

    public void LoadXml(string source)
    {
        XmlSerializer mySerializer = new XmlSerializer(this.GetType());
        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(source)))
        {
            object obj = mySerializer.Deserialize(ms);
            foreach (PropertyInfo p in obj.GetType().GetProperties())
            {
                PropertyInfo p2 = this.GetType().GetProperty(p.Name);
                if (p2 != null && p2.CanWrite)
                {
                    p2.SetValue(this, p.GetValue(obj, null), null);
                }
            }
        }
    }

}