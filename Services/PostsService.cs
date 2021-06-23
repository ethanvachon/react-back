using System;
using System.Collections.Generic;
using react_back.Models;
using react_back.Repositories;

namespace react_back.Services
{
  public class PostsService
  {
    private readonly PostsRepository _repo;

    public PostsService(PostsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Post> GetAll()
    {
      return _repo.GetAll();
    }

    internal object Get(int id)
    {
      Post post = _repo.GetOne(id);
      if (post == null)
      {
        throw new Exception("invalid id");
      }
      return post;
    }

    internal Post Create(Post newPost)
    {
      newPost.Id = _repo.Create(newPost);
      return newPost;
    }

    internal Post Edit(Post newPost, string id)
    {
      Post preEdit = _repo.GetOne(newPost.Id);
      if (preEdit == null)
      {
        throw new Exception("invalid id");
      }
      if (preEdit.CreatorId != id)
      {
        throw new Exception("cannot edit if you are not the creator");
      }
      return _repo.Edit(newPost);
    }

    internal object Delete(int postId, string userId)
    {
      Post preDelete = _repo.GetOne(postId);
      if (preDelete == null)
      {
        throw new Exception("invalid id");
      }
      if (preDelete.CreatorId != userId)
      {
        throw new Exception("cannot delete if you are not the creator");
      }
      _repo.Delete(postId);
      return "deleted";
    }
  }
}