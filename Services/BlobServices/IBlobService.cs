using System;

namespace reymani_web_api.Services.BlobServices;

public interface IBlobService
{
  public Task UploadObject(IFormFile file, string codeObj, CancellationToken ct);
  public Task<string> PresignedGetUrl(string objPath, CancellationToken ct);
  public Task<bool> ValidateExistanceObject(string objPath, CancellationToken ct);
}
