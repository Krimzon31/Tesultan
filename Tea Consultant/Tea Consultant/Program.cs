using SignalR;

namespace Tea_Consultant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSignalR();      // ���������� ������� SignalR

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapHub<ChatHub>("/chat");   // ChatHub ����� ������������ ������� �� ���� /chat

            app.Run();
        }
    }
}