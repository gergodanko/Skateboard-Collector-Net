using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SkateboardCollector.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardCollector.Services
{
    public class DataBaseService : IDataBaseService
    {
        private static readonly string _conn = Program.connectionString;
        //private static NpgsqlConnection conn = new NpgsqlConnection(_conn);
        [HttpGet]
        public List<User> GetAllUser()
        {
            List<User> allUser = new List<User>();

            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM users", conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int userId = int.Parse(reader["user_id"].ToString());
                        string userEmail = reader["user_email"].ToString();
                        string nickname = reader["nickname"].ToString();
                        string password = reader["pw"].ToString();
                        User user = new User(userId, userEmail, nickname, password);
                        allUser.Add(user);
                    }
                    reader.Close();
                }
                conn.Close();
            }

            return allUser;

        }
        public User Login(string email, string password)
        {
            var user = GetOneUser(email);
            if (user == null)
            {
                return null;
            }
            else if (user.UserPw != password)
            {
                return null;
            }
            else
            {
                return user;
            }
        }
        public User GetOneUser(string email)
        {
            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM users WHERE user_email = '{email}'  ", conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int userId = int.Parse(reader["user_id"].ToString());
                        string userEmail = reader["user_email"].ToString();
                        string nickname = reader["nickname"].ToString();
                        string password = reader["pw"].ToString();
                        return new User(userId, userEmail, nickname, password);

                    }
                    reader.Close();
                }
                conn.Close();

            }
            return null;
        }
        public void RegisterUser(string nickname, string email, string password)
        {
            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO users(user_email,nickname,pw) VALUES((@email),(@nickname),(@password)); ", conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@nickname", nickname);
                    cmd.Parameters.AddWithValue("@password", password);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Npgsql.NpgsqlException)
                    {
                        conn.Close();
                    }
                }

            }
        }
        public User GetUserFromSkateboardId(int skateboardId)
        {
            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand($"SELECT users.user_id , nickname , user_email, pw FROM skateboards INNER JOIN users on users.user_id = skateboards.user_id WHERE skateboard_id = {skateboardId}", conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int userId = int.Parse(reader["user_id"].ToString());
                        string userEmail = reader["user_email"].ToString();
                        string nickname = reader["nickname"].ToString();
                        string password = reader["pw"].ToString();
                        return new User(userId, userEmail, nickname, password);

                    }
                    reader.Close();
                }
                conn.Close();

            }
            return null;
        }
        public List<Deck> GetAllDecks()
        {
            List<Deck> allDecks = new List<Deck>();

            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM deck", conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int deckId = int.Parse(reader["deck_id"].ToString());
                        string deckBrand = reader["deck_brand"].ToString();
                        float deckWidth = float.Parse(reader["deck_width"].ToString());
                        float deckLength = float.Parse(reader["deck_length"].ToString());
                        if (deckId != 0)
                        {
                            Deck deck = new Deck(deckId, deckBrand, deckWidth, deckLength);
                            allDecks.Add(deck);
                        }
                    }
                    reader.Close();
                }
                conn.Close();
            }

            return allDecks;

        }
        public List<Truck> GetAllTrucks()
        {
            List<Truck> allTrucks = new List<Truck>();

            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM trucks", conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int truckId = int.Parse(reader["trucks_id"].ToString());
                        string truckBrand = reader["trucks_brand"].ToString();
                        float truckSize = float.Parse(reader["trucks_size"].ToString());
                        if (truckId != 0)
                        {
                            Truck truck = new Truck(truckId, truckBrand, truckSize);
                            allTrucks.Add(truck);
                        }
                    }
                    reader.Close();
                }
                conn.Close();
            }

            return allTrucks;

        }
        public List<Wheels> GetAllWheels()
        {
            List<Wheels> allWheels = new List<Wheels>();

            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM wheels", conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int wheelsId = int.Parse(reader["wheels_id"].ToString());
                        string wheelsBrand = reader["wheels_brand"].ToString();
                        int wheelsSize = int.Parse(reader["wheels_size"].ToString());
                        string wheelsHardness = reader["wheels_hardness"].ToString();
                        if (wheelsId != 0)
                        {
                            Wheels wheels = new Wheels(wheelsId, wheelsBrand, wheelsSize, wheelsHardness);
                            allWheels.Add(wheels);
                        }
                    }
                    reader.Close();
                }
                conn.Close();
            }

            return allWheels;

        }
        public Deck GetDeckById(int id)
        {
            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM deck WHERE deck_id = (@id)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int deckId = int.Parse(reader["deck_id"].ToString());
                        string deckBrand = reader["deck_brand"].ToString();
                        float deckWidth = float.Parse(reader["deck_width"].ToString());
                        float deckLength = float.Parse(reader["deck_length"].ToString());
                        Deck deck = new Deck(deckId, deckBrand, deckWidth, deckLength);
                        return deck;
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return null;

        }
        public Truck GetTruckById(int id)
        {
            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM trucks WHERE trucks_id = (@id)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int trucksId = int.Parse(reader["trucks_id"].ToString());
                        string trucksBrand = reader["trucks_brand"].ToString();
                        float trucksSize = float.Parse(reader["trucks_size"].ToString());
                        Truck truck = new Truck(trucksId, trucksBrand, trucksSize);
                        return truck;
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return null;

        }
        public Wheels GetWheelsById(int id)
        {
            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM wheels WHERE wheels_id = (@id)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int wheelsId = int.Parse(reader["wheels_id"].ToString());
                        string wheelsBrand = reader["wheels_brand"].ToString();
                        int wheelsSize = int.Parse(reader["wheels_size"].ToString());
                        string wheelsHardness = reader["wheels_hardness"].ToString();

                        Wheels wheels = new Wheels(wheelsId, wheelsBrand, wheelsSize, wheelsHardness);
                        return wheels;
                    }
                    reader.Close();

                }
                conn.Close();
            }
            return null;

        }
        public void AddSkateboardSlot(int userId)
        {
            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO skateboards(user_id,deck_id,wheels_id,trucks_id) VALUES((@userId), 0, 0, 0); ", conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Npgsql.NpgsqlException)
                    {
                        conn.Close();
                    }
                }

            }
        }

        public void RemoveSkateboardSlot(int skateboardId)
        {
            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM skateboards WHERE skateboard_id = (@skateboardId);", conn))
                {
                    cmd.Parameters.AddWithValue("@skateboardId", skateboardId);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Npgsql.NpgsqlException)
                    {
                        conn.Close();
                    }
                }

            }
        }
        public List<Skateboard> GetUserSkateboards(int userId) {
            List<Skateboard> userSkateboards = new List<Skateboard>();

            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM skateboards WHERE user_id = (@userId);", conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int skateboardId = int.Parse(reader["skateboard_id"].ToString());
                        int deckId = int.Parse(reader["deck_id"].ToString());
                        int wheelsId = int.Parse(reader["wheels_id"].ToString());
                        int truckId = int.Parse(reader["trucks_id"].ToString());
                        Deck deck = GetDeckById(deckId);
                        Truck truck = GetTruckById(truckId);
                        Wheels wheels = GetWheelsById(wheelsId);
                        Skateboard skateboard = new Skateboard(skateboardId, userId, deck, wheels, truck);
                        userSkateboards.Add(skateboard);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return userSkateboards;
        }
        public void UpdateUserBoard(int skateboardId, int hardwareId, string hardwareType)
        {
            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                if (hardwareType == "Deck")
                {
                    using (var cmd = new NpgsqlCommand("UPDATE skateboards SET deck_id =(@hardwareId) WHERE skateboard_id = (@skateboardId)", conn))
                    {
                        cmd.Parameters.AddWithValue("@hardwareId", hardwareId);
                        cmd.Parameters.AddWithValue("@skateboardId", skateboardId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (hardwareType == "Truck")
                {
                    using (var cmd = new NpgsqlCommand("UPDATE skateboards SET trucks_id =(@hardwareId) WHERE skateboard_id = (@skateboardId)", conn))
                    {
                        cmd.Parameters.AddWithValue("@hardwareId", hardwareId);
                        cmd.Parameters.AddWithValue("@skateboardId", skateboardId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (var cmd = new NpgsqlCommand("UPDATE skateboards SET wheels_id =(@hardwareId) WHERE skateboard_id = (@skateboardId)", conn))
                    {
                        cmd.Parameters.AddWithValue("@hardwareId", hardwareId);
                        cmd.Parameters.AddWithValue("@skateboardId", skateboardId);
                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
        }
        public List<LikeList> GetLikeListForBoards()
        {
            var likes = new List<LikeList>();
            bool foundBoard;
            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT l.user_id as likedUserId, s.skateboard_id as skateboardId,u.nickname as userNickname,s.user_id as skateboardUserId, s.deck_id as deckId, s.wheels_id as wheelsId, s.trucks_id as trucksId FROM liked AS l INNER JOIN skateboards AS s on s.skateboard_id = l.skateboard_id INNER JOIN users AS u on u.user_id = s.user_id", conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        foundBoard = false;
                        int likedUserId = int.Parse(reader["likedUserId"].ToString());
                        int skateboardId = int.Parse(reader["skateboardId"].ToString());
                        string userNickname = reader["userNickname"].ToString();
                        int skateboardUserId = int.Parse(reader["skateboardUserId"].ToString());
                        int deckId = int.Parse(reader["deckId"].ToString());
                        int wheelsId = int.Parse(reader["wheelsId"].ToString());
                        int truckId = int.Parse(reader["trucksId"].ToString());
                        Deck deck = GetDeckById(deckId);
                        Truck truck = GetTruckById(truckId);
                        Wheels wheels = GetWheelsById(wheelsId);
                        Skateboard skateboard = new Skateboard(skateboardId, skateboardUserId, deck, wheels, truck);
                        foreach (LikeList like in likes)
                        {
                            if (like.LikeSkateboard.SkateboardId.Equals(skateboard.SkateboardId))
                            {
                                like.LikeUsers.Add(likedUserId);
                                foundBoard = true;
                                break;
                            }
                        }
                        if (foundBoard == false)
                        {
                            LikeList like_list = new LikeList(new List<int>(), skateboard, userNickname);
                            like_list.LikeUsers.Add(likedUserId);
                            likes.Add(like_list);
                        }
                    }
                    reader.Close();
                }
                conn.Close();
                List<Skateboard> completeSkateboards = GetBoardsForLikeList();
                foreach (Skateboard board in completeSkateboards)
                {
                    foundBoard = false;
                    foreach (LikeList like in likes)
                    {
                        if (like.LikeSkateboard.SkateboardId.Equals(board.SkateboardId))
                        {
                            foundBoard = true;
                            break;
                            
                        }
                        
                    }
                    if (foundBoard == false)
                    {
                        LikeList like_list = new LikeList(new List<int>(), board, GetUserFromSkateboardId(board.SkateboardId).UserNickname);
                        likes.Add(like_list);
                    }
                }
            }
            return likes;
        }
        public List<Skateboard> GetBoardsForLikeList()
        {
            List<Skateboard> completeSkateboards = new List<Skateboard>();

            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("select * from skateboards WHERE deck_id != 0 AND wheels_id != 0 AND trucks_id != 0", conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int skateboardId = int.Parse(reader["skateboard_id"].ToString());
                        int userId = int.Parse(reader["user_id"].ToString());
                        int deckId = int.Parse(reader["deck_id"].ToString());
                        int wheelsId = int.Parse(reader["wheels_id"].ToString());
                        int truckId = int.Parse(reader["trucks_id"].ToString());
                        Deck deck = GetDeckById(deckId);
                        Truck truck = GetTruckById(truckId);
                        Wheels wheels = GetWheelsById(wheelsId);
                        Skateboard skateboard = new Skateboard(skateboardId, userId, deck, wheels, truck);
                        completeSkateboards.Add(skateboard);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return completeSkateboards;
        }
        
        public void GiveALike(int userId,int skateboardId)
        {
            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO liked(user_id,skateboard_id) VALUES((@userId),(@skateboardId)); ", conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@skateboardId", skateboardId);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Npgsql.NpgsqlException)
                    {
                        conn.Close();
                    }
                }

            }
        }
    } }
    

