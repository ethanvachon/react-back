using System;
using System.Collections.Generic;
using react_back.Models;

namespace react_back.Repositories
{
  public class CommentsRepository
  {
    internal IEnumerable<Comment> GetByPost(int id)
    {
      throw new NotImplementedException();
    }

    internal IEnumerable<Comment> GetAll()
    {
      throw new NotImplementedException();
    }

    internal Comment GetOne(int id)
    {
      throw new NotImplementedException();
    }

    internal int Post(Comment newComment)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int commentId)
    {
      throw new NotImplementedException();
    }

    internal object Edit(Comment newComment)
    {
      throw new NotImplementedException();
    }
  }
}