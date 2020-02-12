using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    [ServiceContract]
    public interface IService1
    {
        String GetNickname(int id);
        [OperationContract]
        List<Account> GetAllAccounts();
        [OperationContract]
        bool IsUniqueLogin(string login);
        [OperationContract]
        bool IsUniqueEmail(string email);
        [OperationContract]
        bool IsUniqueNickname(string nickname);
        [OperationContract]
        void AddAccount(Account account);
        [OperationContract]
        Account GetAccount(string login);
        [OperationContract]
        void UpdateAccount(int id, Account account);
        [OperationContract]
        byte[] GetAvatar(int id);
        [OperationContract]
        List<Game> GetAllGamesByDateOfAddiction();
        [OperationContract]
        double GetGameScore(int id);
        [OperationContract]
        double GetAccountAverageScore(int id);
        [OperationContract]
        int GetNumberOfScores(int id);
        [OperationContract]
        int GetSumOfNewReviews(int id);
        [OperationContract]
        int GetGameMembers(int id);
        [OperationContract]
        Game GetGameByTitle(string title);
        [OperationContract]
        Game GetGameById(int gameID);
        [OperationContract]
        void UpdateGame(int id, Game game);
        [OperationContract]
        string GetStudioName(int studioID);
        [OperationContract]
        string GetGamePlatforms(int gameID);
        [OperationContract]
        string GetPlatform(int platformID);
        [OperationContract]
        string GetGameGenres(int gameID);
        [OperationContract]
        string GetGenre(int genreID);
        [OperationContract]
        List<GameList> GetGameListByAccountId(int accountID);
        [OperationContract]
        List<Follow> GetFollowListByAccountId(int accountID);
        [OperationContract]
        void DeleteFollowEntry(int accountID, int gameID);
        [OperationContract]
        void DeleteGameListEntry(int accountID, int gameID);
        [OperationContract]
        void InsertNewFollow(Follow follow);
        [OperationContract]
        void UpdateGameList(GameList gameList);
        [OperationContract]
        void InsertNewGameList(GameList gameList);
        [OperationContract]
        List<Friend> GetFriendListByAccountId(int accountID);
        [OperationContract]
        Account GetAccountById(int accountID);
        [OperationContract]
        void DeleteFriend(int accountID, int friendID);
        [OperationContract]
        void InsertFriend(Friend friend);
        [OperationContract]
        void UpdateFriend(int accountID, int friendID, Friend friend);
        [OperationContract]
        List<GameList> GetGameListByGameId(int gameID);
        [OperationContract]
        List<Friend> GetFriendRequests(int accountID);
        [OperationContract]
        void UpdateFollow(int accountID, int gameID);
        [OperationContract]
        List<Friend> GetFriendListBothAcceptedByAccountId(int accountID);
        [OperationContract]
        List<Studio> GetStudioList();
        [OperationContract]
        void InsertNewStudio(Studio studio);
        [OperationContract]
        List<Platform> GetAllPlatforms();
        [OperationContract]
        List<Genre> GetAllGenres();
        [OperationContract]
        bool IsGameAlreadyExist(string title);
        [OperationContract]
        Studio GetStudioByName(string studio);
        [OperationContract]
        void InsertNewGame(Game game);
        [OperationContract]
        void InsertNewGamePlatform(Game_platform game_Platform);
        [OperationContract]
        void InsertNewGameGenre(Game_genre game_Genre);
        [OperationContract]
        int GetGameId(string title);
        [OperationContract]
        int GetPlatformId(string platform);
        [OperationContract]
        int GetGenreId(string genre);
        [OperationContract]
        List<Game> GetRequestedGames();
        [OperationContract]
        List<Studio> GetRequestedStudios();
        [OperationContract]
        List<string> GetGamePlatformsList(int gameID);
        [OperationContract]
        List<string> GetGameGenresList(int gameID);
        [OperationContract]
        void DeleteAllGamePlatforms(int gameID);
        [OperationContract]
        void DeleteAllGameGenres(int gameID);
        [OperationContract]
        void DeleteGameEntry(int gameID);
        [OperationContract]
        void UpdateStudio(int studioID, Studio studio);
        [OperationContract]
        void DeleteStudio(int studioID);
        [OperationContract]
        void InsertNewPlatform(Platform platform);
        [OperationContract]
        void InsertNewGenre(Genre genre);
    }
}
