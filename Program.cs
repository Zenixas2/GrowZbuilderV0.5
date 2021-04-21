// Decompiled with JetBrains decompiler
// Type: WebhookStealer.Program
// Assembly: ZenBuilder, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D7E1FA2E-5F50-41A6-84C5-F3758C34FFF5
// Assembly location: C:\Users\kol\Desktop\Naujas aplankas (6)\ZenBuilder\Uusi kansio (2)\ZenBuilder.exe

using System;
using System.Windows.Forms;

namespace WebhookStealer
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
