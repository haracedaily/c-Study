using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using static Supabase.Postgrest.Constants;

namespace WinFormsApp1
{
    public sealed class DataBase
    {
        private string url;
        private string key;

        private static readonly Lazy<DataBase> instance = new Lazy<DataBase>(() => new DataBase());

        public static DataBase GetInstance() => instance.Value;
        //public static DataBase GetInstance() => new DataBase();
        public Supabase.Client supa { get; }

        DataBase()
        {
            // 데이터베이스 연결 및 초기화 작업을 수행합니다.
            // 예: Supabase 클라이언트 초기화, 테이블 생성 등
            Env.Load(); // .env 파일 로드
            url = Environment.GetEnvironmentVariable("SUPABASE_URL");
            key = Environment.GetEnvironmentVariable("SUPABASE_KEY");
            
            if (url is not null && key is not null)
            {
                var options = new Supabase.SupabaseOptions
                {
                    AutoConnectRealtime = true
                };
                supa = new Supabase.Client(url, key, options);

                // Supabase 초기화 (비동기)
                Task.Run(async () =>
                {
                    await supa.InitializeAsync();
                    
                });
                
            }
            
        }
    }
}
