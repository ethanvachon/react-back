using System;
using react_back.Models;
using react_back.Repositories;

namespace react_back.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    internal object GetOrCreateProfile(Profile userInfo)
    {
      Profile profile = _repo.GetOne(userInfo.Id);
      if (profile == null)
      {
        return _repo.Create(userInfo);
      }
      return profile;
    }

    internal object GetAll()
    {
      return _repo.GetAll();
    }

    internal Profile GetProfileById(string id)
    {
      Profile profile = _repo.GetOne(id);
      if (profile == null)
      {
        throw new Exception("invalid id");
      }
      return profile;
    }

    internal object Edit(Profile newProfile)
    {
      return _repo.Edit(newProfile);
    }
  }
}