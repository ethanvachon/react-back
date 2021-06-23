using System;
using System.Collections.Generic;
using react_back.Models;
using react_back.Repositories;

namespace react_back.Services
{
  public class CommentsService
  {
    private readonly CommentsRepository _repo;

    public CommentsService(CommentsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Comment> GetByPost(int id)
    {
      return _repo.GetByPost(id);
    }

    internal IEnumerable<Comment> GetAll()
    {
      return _repo.GetAll();
    }

    internal Comment Post(Comment newComment)
    {
      newComment.Id = _repo.Post(newComment);
      return newComment;
    }

    internal object Edit(Comment newComment, string id)
    {
      Comment preEdit = _repo.GetOne(newComment.Id);
      if (preEdit == null)
      {
        throw new Exception("invalid id");
      }
      if (preEdit.CreatorId != id)
      {
        throw new Exception("cannot edit if you are not the creator");
      }
      return _repo.Edit(newComment);
    }

    internal string Delete(int commentId, string userId)
    {
      Comment preDelete = _repo.GetOne(commentId);
      if (preDelete == null)
      {
        throw new Exception("invalid id");
      }
      if (preDelete.CreatorId != userId)
      {
        throw new Exception("cannot delete if you are not the creator");
      }
      _repo.Delete(commentId);
      return "deleted";
    }
  }
}