using Newtonsoft.Json;
using PoeStashServer.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace PoeStashServer
{
    class Program
    {
        private const string POEStashURL = "http://api.pathofexile.com/public-stash-tabs";
        private static string currentId = "0";
        private static int filecounter = 0;
        private static List<Stash> stashesGlobalList = new List<Stash>();

        static void Main(string[] args)
        {
            // Initial request
            var content = WebRequester.GET(POEStashURL);
            FileCreator.CreateFileAndWriteContent("file" + filecounter + ".txt", content);
            
            dynamic response = JsonConvert.DeserializeObject(content);

            currentId = response.next_change_id;
            AddInfoFromJSON(response.stashes);

            // Timer
            var myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(myEvent);
            myTimer.Interval = 2000;  
            myTimer.Enabled = true;

            // Console so app doesn't close
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();

        }

        // Implement a call with the right signature for events going off
        private static void myEvent(object source, ElapsedEventArgs e)
        {
            ++filecounter;
            Console.WriteLine("getting data with id =" + currentId);
            var content = WebRequester.GET(POEStashURL + "/?id=" + currentId);
            FileCreator.CreateFileAndWriteContent("file" + filecounter + ".txt", content);

            dynamic response = JsonConvert.DeserializeObject(content);
            currentId = response.next_change_id;
            AddInfoFromJSON(response.stashes);
        }

        private static void AddInfoFromJSON(dynamic stashes)
        {
            foreach (var stash in stashes)
            {
                if (stash.@public.Value)
                {
                    var newStash = new Stash();
                    newStash.accountName = stash.accountName;
                    newStash.lastCharacterName = stash.lastCharacterName;
                    newStash.id = stash.id;
                    newStash.stash = stash.stash;
                    newStash.stashType = stash.stashType;
                    newStash.@public = stash.@public;
                    stashesGlobalList.Add(newStash);

                    var listOfItems = new List<Item>();
                    foreach (var currentItem in stash.items)
                    {
                        var createdItem = new Item();
                        createdItem.verified = currentItem.verified;
                        createdItem.w = currentItem.w;
                        createdItem.h = currentItem.h;
                        createdItem.ilvl = currentItem.ilvl;
                        createdItem.icon = currentItem.icon;
                        createdItem.league = currentItem.league;
                        createdItem.id = currentItem.id;
                        createdItem.name = currentItem.name;
                        createdItem.typeLine = currentItem.typeLine;
                        createdItem.identified = currentItem.identified;
                        createdItem.corrupted = currentItem.corrupted;
                        createdItem.lockedToCharacter = currentItem.lockedToCharacter;
                        createdItem.frameType = currentItem.frameType;
                        createdItem.x = currentItem.x;
                        createdItem.y = currentItem.y;
                        createdItem.inventoryId = currentItem.inventoryId;
                        createdItem.descrText = currentItem.descrText;
                        createdItem.secDescrText = currentItem.secDescrText;
                        createdItem.support = currentItem.support;
                        listOfItems.Add(createdItem);
                    }

                    newStash.items = listOfItems;
                }
            }
        }

    }
}
