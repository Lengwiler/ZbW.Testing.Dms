using System;

namespace ZbW.Testing.Dms.Client.Services.Impl
{
 internal class GuidGeneratorService : IGuidGeneratorService
  {
    public Guid GetNewGuid()
    {
      return Guid.NewGuid();
    }
  }
}
