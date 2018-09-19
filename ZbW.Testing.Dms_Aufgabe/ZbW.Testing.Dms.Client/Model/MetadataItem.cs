using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.ViewModels;
using ZbW.Testing.Dms.Client.Views;

namespace ZbW.Testing.Dms.Client.Model
{
    public class MetadataItem : IXmlSerializable
    {
        // TODO: Write your Metadata properties here

        public string Benutzer { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime Erfassungsdatum { get; set; }
        public bool IsRemoveFileEnabled { get; set; }
        public string SelectedTypItem { get; set; }
        public string Stichwoerter { get; set; }
        public DateTime? ValutaDatum { get; set; }
        public string FilePath { get; set; }

        internal MetadataItem(DocumentDetailViewModel viewModel)
        {
            Benutzer = viewModel.Benutzer;
            Bezeichnung = viewModel.Bezeichnung;
            Erfassungsdatum = viewModel.Erfassungsdatum;
            IsRemoveFileEnabled = viewModel.IsRemoveFileEnabled;
            SelectedTypItem = viewModel.SelectedTypItem;
            Stichwoerter = viewModel.Stichwoerter;
            ValutaDatum = viewModel.ValutaDatum;
            FilePath = viewModel.FilePath;
        }

        public MetadataItem()
        {
            
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            Benutzer = reader.ReadElementContentAsString();
            Bezeichnung = reader.ReadElementContentAsString();
            Erfassungsdatum = reader.ReadElementContentAsDateTime();
            IsRemoveFileEnabled = reader.ReadElementContentAsBoolean();
            Stichwoerter = reader.ReadElementContentAsString();
            SelectedTypItem = reader.ReadElementContentAsString();
            ValutaDatum = reader.ReadElementContentAsDateTime();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Benutzer", Benutzer);
            writer.WriteElementString("Bezeichnung", Bezeichnung);
            writer.WriteElementString("Erfassungsdatum", Erfassungsdatum.ToString());
            writer.WriteElementString("IsRemoveFileEnabled", IsRemoveFileEnabled.ToString());
            writer.WriteElementString("Stichwoerter", Stichwoerter);
            writer.WriteElementString("SelectedTypItem", SelectedTypItem.ToString());
            writer.WriteElementString("ValutaDatum", ValutaDatum.ToString());
        }

    }
}