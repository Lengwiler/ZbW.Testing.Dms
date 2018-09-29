using System;

namespace ZbW.Testing.Dms.Client.Services.Impl
{
  public class FilenameGeneratorService : IFilenameGeneratorService
  {
    public string GetContentFilename(Guid guid, string extension)
    {
      return extension != null ? guid + "_Content" + extension : null;
    }

    public string GetMetadataFilename(Guid guid)
    {
      return guid + "_Metadata.xml";
    }
  }
}
