using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Collections.ObjectModel;
using System.Text;

namespace WcfServiceLibrary
{
    public class Service1 : IService1
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public String GetNickname(int id)
        {
            var data = (from p in dc.Accounts
                       where p.Id == id
                       select p).FirstOrDefault();
            return data.Nickname;
        }
        public List<Account> GetAllAccounts()
        {
            var data = from p in dc.Accounts
                       select p;
            return data.ToList();
        }
        public bool IsUniqueLogin(string login)
        {
            var data = (from p in dc.Accounts
                       where p.Login == login
                       select p).FirstOrDefault();
            if (data is null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsUniqueEmail(string email)
        {
            var data = (from p in dc.Accounts
                        where p.Email == email
                        select p).FirstOrDefault();
            if (data is null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsUniqueNickname(string nickname)
        {
            var data = (from p in dc.Accounts
                        where p.Nickname == nickname
                        select p).FirstOrDefault();
            if (data is null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddAccount(Account account)
        {
            dc.Accounts.InsertOnSubmit(account);
            dc.SubmitChanges();
        }
        public Account GetAccount(string login)
        {
            var data = (from p in dc.Accounts
                       where p.Login == login
                       select p).FirstOrDefault();
            return data;
        }
        public void UpdateAccount(int id, Account account)
        {
            var data = (from p in dc.Accounts
                        where p.Id == id
                        select p).FirstOrDefault();
            if (data != null)
            {
                data.Login = account.Login;
                data.Password = account.Password;
                data.Email = account.Email;
                data.Nickname = account.Nickname;
                data.Avatar = account.Avatar;
                data.Joined = account.Joined;
                data.Sex = account.Sex;
                data.IsModerator = account.IsModerator;
                data.IsAdmin = account.IsAdmin;
                data.IsActivated = account.IsActivated;
            }
            dc.SubmitChanges();
        }
        public byte[] GetAvatar(int id)
        {
            var data = (from p in dc.Accounts
                        where p.Id == id
                        select p.Avatar).FirstOrDefault().ToArray();
            return data;
        }
        public List<Game> GetAllGamesByDateOfAddiction()
        {
            var data = from p in dc.Games
                       where p.IsAccepted == true
                       orderby p.DateOfAddiction descending
                       select p;
            return data.ToList();
        }
        public double GetGameScore(int id)
        {
            var data = dc.avg_score(id);
            if (data == null)
            {
                return 0.0;
            }
            return (double)data;
        }
        public double GetAccountAverageScore(int id)
        {
            var data = dc.account_avg_score(id);
            if (data == null)
            {
                return 0.0;
            }
            return (double)data;
        }
        public int GetNumberOfScores(int id)
        {
            var data = dc.number_of_scores(id);
            if (data == null)
            {
                return 0;
            }
            return (int)data;
        }
        public int GetSumOfNewReviews(int id)
        {
            var data = dc.sum_of_newreviews(id);
            if (data == null)
            {
                return 0;
            }
            return (int)data;
        }
        public int GetGameMembers(int id)
        {
            var data = dc.number_of_game_entries(id);
            if (data == null)
            {
                return 0;
            }
            return (int)data;
        }
        public Game GetGameByTitle(string title)
        {
            var data = (from p in dc.Games
                        where p.Title == title
                        select p).FirstOrDefault();
            return data;
        }
        public Game GetGameById(int gameID)
        {
            if (gameID < 0)
            {
                throw new ArgumentException("Game id can't be a negative value.");
            }
            var data = (from p in dc.Games
                        where p.Id == gameID
                        select p).FirstOrDefault();
            return data;
        }
        public void UpdateGame(int id, Game game)
        {
            var data = (from p in dc.Games
                        where p.Id == id
                        select p).FirstOrDefault();
            if (data != null)
            {
                data.Title = game.Title;
                data.Studio_Id = game.Studio_Id;
                data.Publisher = game.Publisher;
                data.Image = game.Image;
                data.Premiere = game.Premiere;
                data.Description = game.Description;
                data.DateOfAddiction = game.DateOfAddiction;
                data.IsAccepted = game.IsAccepted;
            }
            dc.SubmitChanges();
        }
        public string GetStudioName(int studioID)
        {
            var data = (from p in dc.Studios
                        where p.Id == studioID
                        select p).FirstOrDefault();
            if (data == null)
                return "";
            return data.Studio1;
        }
        public string GetGamePlatforms(int gameID)
        {
            var data = from p in dc.Game_platforms
                       where p.Game_Id == gameID
                       select p;
            if (data == null)
                return "";
            var platforms = data.ToArray();
            string result = "";
            foreach (var platform in platforms)
            {
                result += GetPlatform(platform.Platform_Id) + " ";
            }
            return result;
        }
        public string GetPlatform(int platformID)
        {
            var data = (from p in dc.Platforms
                        where p.Id == platformID
                        select p).FirstOrDefault();
            if (data == null)
                return "";
            return data.Platform1;
        }
        public string GetGameGenres(int gameID)
        {
            var data = from p in dc.Game_genres
                       where p.Game_Id == gameID
                       select p;
            if (data == null)
                return "";
            var genres = data.ToArray();
            string result = "";
            foreach (var genre in genres)
            {
                result += GetGenre(genre.Genre_Id) + " ";
            }
            return result;
        }
        public string GetGenre(int genreID)
        {
            var data = (from p in dc.Genres
                        where p.Id == genreID
                        select p).FirstOrDefault();
            if (data == null)
                return "";
            return data.Genre1;
        }
        public List<GameList> GetGameListByAccountId(int accountID)
        {
            var data = from p in dc.GameLists
                        where p.Account_Id == accountID
                        select p;
            return data.ToList();
        }
        public List<Follow> GetFollowListByAccountId(int accountID)
        {
            var data = from p in dc.Follows
                       where p.Account_Id == accountID
                       select p;
            return data.ToList();
        }
        public void DeleteFollowEntry(int accountID, int gameID)
        {
            var data = (from p in dc.Follows
                       where p.Account_Id == accountID && p.Game_Id == gameID
                       select p).FirstOrDefault();
            dc.Follows.DeleteOnSubmit(data);
            dc.SubmitChanges();
        }
        public void DeleteGameListEntry(int accountID, int gameID)
        {
            var data = (from p in dc.GameLists
                        where p.Account_Id == accountID && p.Game_Id == gameID
                        select p).FirstOrDefault();
            dc.GameLists.DeleteOnSubmit(data);
            dc.SubmitChanges();
        }
        public void InsertNewFollow(Follow follow)
        {
            dc.Follows.InsertOnSubmit(follow);
            dc.SubmitChanges();
        }
        public void UpdateGameList(GameList gameList)
        {
            var data = (from p in dc.GameLists
                        where p.Account_Id == gameList.Account_Id && p.Game_Id == gameList.Game_Id
                        select p).FirstOrDefault();
            if (data != null)
            {
                data.Status = gameList.Status;
                data.Score = gameList.Score;
                data.Review = gameList.Review;
            }
            dc.SubmitChanges();
        }
        public void InsertNewGameList(GameList gameList)
        {
            dc.GameLists.InsertOnSubmit(gameList);
            dc.SubmitChanges();
        }
        public List<Friend> GetFriendListByAccountId(int accountID)
        {
            var data = from p in dc.Friends
                       where p.Account_Id == accountID
                       select p;
            return data.ToList();
        }
        public Account GetAccountById(int accountID)
        {
            var data = (from p in dc.Accounts
                        where p.Id == accountID
                        select p).FirstOrDefault();
            if (data == null)
                return null;
            return data;
        }
        public void DeleteFriend(int accountID, int friendID)
        {
            var data = (from p in dc.Friends
                        where p.Account_Id == accountID && p.Friend_Id == friendID
                        select p).FirstOrDefault();
            dc.Friends.DeleteOnSubmit(data);
            dc.SubmitChanges();
        }
        public void InsertFriend(Friend friend)
        {
            dc.Friends.InsertOnSubmit(friend);
            dc.SubmitChanges();
        }
        public void UpdateFriend(int accountID, int friendID, Friend friend)
        {
            var data = (from p in dc.Friends
                        where p.Account_Id == accountID && p.Friend_Id == friendID
                        select p).FirstOrDefault();
            data.IsAcceptedByBoth = friend.IsAcceptedByBoth;
            dc.SubmitChanges();
        }
        public List<GameList> GetGameListByGameId(int gameID)
        {
            var data = from p in dc.GameLists
                       where p.Game_Id == gameID
                       select p;
            return data.ToList();
        }
        public List<Friend> GetFriendRequests(int accountID)
        {
            var data = from p in dc.Friends
                       where p.Friend_Id == accountID && p.IsAcceptedByBoth == false
                       select p;
            return data.ToList();
        }
        public void UpdateFollow(int accountID, int gameID)
        {
            var data = (from p in dc.Follows
                        where p.Account_Id == accountID && p.Game_Id == gameID
                        select p).FirstOrDefault();
            data.NewReview = 0;
            data.DateOfFollowing = DateTime.Now;
            dc.SubmitChanges();
        }
        public List<Friend> GetFriendListBothAcceptedByAccountId(int accountID)
        {
            var data = from p in dc.Friends
                       where p.Account_Id == accountID && p.IsAcceptedByBoth == true
                       select p;
            return data.ToList();
        }
        public List<Studio> GetStudioList()
        {
            var data = from p in dc.Studios
                       select p;
            return data.ToList();
        }
        public void InsertNewStudio(Studio studio)
        {
            dc.Studios.InsertOnSubmit(studio);
            dc.SubmitChanges();
        }
        public List<Platform> GetAllPlatforms()
        {
            var data = from p in dc.Platforms
                       select p;
            return data.ToList();
        }
        public List<Genre> GetAllGenres()
        {
            var data = from p in dc.Genres
                       select p;
            return data.ToList();
        }
        public bool IsGameAlreadyExist(string title)
        {
            var data = (from p in dc.Games
                        where p.Title.ToLower() == title.ToLower()
                        select p).FirstOrDefault();
            if (data == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Studio GetStudioByName(string studio)
        {
            var data = (from p in dc.Studios
                        where p.Studio1.ToLower() == studio.ToLower() && p.IsAccepted == true
                        select p).FirstOrDefault();
            return data;
        }
        public void InsertNewGame(Game game)
        {
            dc.Games.InsertOnSubmit(game);
            dc.SubmitChanges();
        }
        public void InsertNewGamePlatform(Game_platform game_Platform)
        {
            dc.Game_platforms.InsertOnSubmit(game_Platform);
            dc.SubmitChanges();
        }
        public void InsertNewGameGenre(Game_genre game_Genre)
        {
            dc.Game_genres.InsertOnSubmit(game_Genre);
            dc.SubmitChanges();
        }
        public int GetGameId(string title)
        {
            var data = (from p in dc.Games
                        where p.Title.ToLower() == title.ToLower()
                        select p).FirstOrDefault();
            return data.Id;
        }
        public int GetPlatformId(string platform)
        {
            var data = (from p in dc.Platforms
                        where p.Platform1.ToLower() == platform.ToLower()
                        select p).FirstOrDefault();
            if (data == null)
            {
                return -1;
            }
            return data.Id;
        }
        public int GetGenreId(string genre)
        {
            var data = (from p in dc.Genres
                        where p.Genre1.ToLower() == genre.ToLower()
                        select p).FirstOrDefault();
            if (data == null)
            {
                return -1;
            }
            return data.Id;
        }
        public List<Game> GetRequestedGames()
        {
            var data = from p in dc.Games
                       where p.IsAccepted == false
                       select p;
            return data.ToList();
        }
        public List<Studio> GetRequestedStudios()
        {
            var data = from p in dc.Studios
                       where p.IsAccepted == false
                       select p;
            return data.ToList();
        }
        public List<string> GetGamePlatformsList(int gameID)
        {
            var result = new List<string>();
            var data = from p in dc.Game_platforms
                       where p.Game_Id == gameID
                       select p;
            foreach (var game in data)
            {
                result.Add(GetPlatform(game.Platform_Id));
            }
            return result;
        }
        public List<string> GetGameGenresList(int gameID)
        {
            var result = new List<string>();
            var data = from p in dc.Game_genres
                       where p.Game_Id == gameID
                       select p;
            foreach (var game in data)
            {
                result.Add(GetGenre(game.Genre_Id));
            }
            return result;
        }
        public void DeleteAllGamePlatforms(int gameID)
        {
            var data = from p in dc.Game_platforms
                       where p.Game_Id == gameID
                       select p;
            dc.Game_platforms.DeleteAllOnSubmit(data);
            dc.SubmitChanges();
        }
        public void DeleteAllGameGenres(int gameID)
        {
            var data = from p in dc.Game_genres
                       where p.Game_Id == gameID
                       select p;
            dc.Game_genres.DeleteAllOnSubmit(data);
            dc.SubmitChanges();
        }
        public void DeleteGameEntry(int gameID)
        {
            var followData = from p in dc.Follows
                             where p.Game_Id == gameID
                             select p;
            dc.Follows.DeleteAllOnSubmit(followData);
            var gameGenreData = from p in dc.Game_genres
                                where p.Game_Id == gameID
                                select p;
            dc.Game_genres.DeleteAllOnSubmit(gameGenreData);
            var gamePlatfromData = from p in dc.Game_platforms
                                   where p.Game_Id == gameID
                                   select p;
            dc.Game_platforms.DeleteAllOnSubmit(gamePlatfromData);
            var gameListData = from p in dc.GameLists
                               where p.Game_Id == gameID
                               select p;
            dc.GameLists.DeleteAllOnSubmit(gameListData);
            var data = (from p in dc.Games
                        where p.Id == gameID
                        select p).FirstOrDefault();
            dc.Games.DeleteOnSubmit(data);
            dc.SubmitChanges();
        }
        public void UpdateStudio(int studioID, Studio studio)
        {
            var data = (from p in dc.Studios
                        where p.Id == studioID
                        select p).FirstOrDefault();
            data.Studio1 = studio.Studio1;
            data.IsAccepted = studio.IsAccepted;
            data.Indie = studio.Indie;
            dc.SubmitChanges();
        }
        public void DeleteStudio(int studioID)
        {
            var gameData = from p in dc.Games
                           where p.Studio_Id == studioID
                           select p;
            foreach (var item in gameData)
            {
                DeleteGameEntry(item.Id);
            }
            var data = (from p in dc.Studios
                        where p.Id == studioID
                        select p).FirstOrDefault();
            dc.Studios.DeleteOnSubmit(data);
            dc.SubmitChanges();
        }
        public void InsertNewPlatform(Platform platform)
        {
            dc.Platforms.InsertOnSubmit(platform);
            dc.SubmitChanges();
        }
        public void InsertNewGenre(Genre genre)
        {
            dc.Genres.InsertOnSubmit(genre);
            dc.SubmitChanges();
        }
    }
}
