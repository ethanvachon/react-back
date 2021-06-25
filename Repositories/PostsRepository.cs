using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using react_back.Models;

namespace react_back.Repositories
{
  public class PostsRepository
  {
    private readonly IDbConnection _db;

    public PostsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Post> GetAll()
    {
      string sql = @"
      SELECT
      p.*,
      pr.*
      FROM posts p
      JOIN profiles pr ON p.creatorId = pr.id";
      return _db.Query<Post, Profile, Post>(sql, (post, profile) => { post.Creator = profile; return post; }, splitOn: "id");
    }

    internal Post GetOne(int id)
    {
      string sql = @"
      SELECT
      p.*,
      pr.*
      FROM posts p
      JOIN profiles pr ON p.creatorId = pr.id
      WHERE p.id = @id";
      return _db.Query<Post, Profile, Post>(sql, (post, profile) => { post.Creator = profile; return post; }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal int Create(Post newPost)
    {
      string sql = @"
      INSERT INTO questions
      (time, body, creatorId)
      VALUES 
      (@Time, @Body, @CreatorId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newPost);
    }

    internal Post Edit(Post newPost)
    {
      string sql = @"
      UPDATE posts
      SET
      body = @Body
      WHERE id = @id;";
      _db.Execute(sql, newPost);
      return newPost;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM posts WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}