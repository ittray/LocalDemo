using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Org.Apache.Zookeeper.Data;
using ZooKeeperNet;

namespace zookeeperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoWatcher watcher = new DemoWatcher();
            ZooKeeper zk = new ZooKeeper("127.0.0.1:2181", new TimeSpan(16000), watcher);
            //zk.Create("/master", BitConverter.GetBytes(230), ACL, CreateMode.Ephemeral);
            checkMaster(zk);

            Console.ReadLine();
        }

        private static bool checkMaster(ZooKeeper zk)
        {
            while (true)
            {
                try
                {
                    Stat stat = new Stat();
                    byte[] data = zk.GetData("/master", false, stat);
                    var isLeader = System.Text.Encoding.UTF8.GetString(data).Equals("230");
                    return true;
                }
                catch (KeeperException.NoNodeException)
                {

                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }

    public class DemoWatcher : IWatcher
    {
        public void Process(WatchedEvent @event)
        {
            Console.WriteLine(@event);
        }
    }
}
