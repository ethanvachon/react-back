using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using react_back.Models;

namespace react_back.Repositories
{
  public class CommentsRepository
  {
    private readonly IDbConnection _db;

    public CommentsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Comment> GetByPost(int id)
    {
      string sql = @"
      SELECT
      c.*,
      p.*,
      pr.*
      FROM comments c
      JOIN posts p ON c.postId = p.id
      JOIN profiles pr ON c.creatorId = pr.id
      WHERE postId = @id;";
      return _db.Query<Comment, Post, Profile, Comment>(sql, (comment, post, profile) => { comment.Post = post; comment.Creator = profile; return comment; }, new { id }, splitOn: "id");
    }

    internal IEnumerable<Comment> GetAll()
    {
      throw new NotImplementedException();
    }

    internal Comment GetOne(int id)
    {
      string sql = @"
      SELECT 
      c.*,
      pr.*,
      p.*
      FROM comments c
      JOIN posts p ON c.postId = p.id
      JOIN profiles pr ON c.creatorId = pr.id
      WHERE id = @id";
      return _db.Query<Comment, Post, Profile, Comment>(sql, (comment, post, profile) => { comment.Post = post; comment.Creator = profile; return comment; }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal int Post(Comment newComment)
    {
      string sql = @"
      INSERT INTO comments
      (time, postId, body, creatorId)
      VALUES 
      (@Time, @PostId, @Body, @CreatorId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newComment);
    }
    internal object Edit(Comment newComment)
    {
      string sql = @"
      UPDATE comments
      SET
      body = @Body
      WHERE id = @id;";
      _db.Execute(sql, newComment);
      return newComment;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM comments WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}