// Decompiled with JetBrains decompiler
// Type: WebhookStealer.Properties.Resources
// Assembly: GrowZBuilder, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D7E1FA2E-5F50-41A6-84C5-F3758C34FFF5
// Assembly location: C:\Users\kol\Desktop\Naujas aplankas (6)\GrowzBuilder\Uusi kansio (2)\GrowZBuilder.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace WebhookStealer.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (WebhookStealer.Properties.Resources.resourceMan == null)
          WebhookStealer.Properties.Resources.resourceMan = new ResourceManager("WebhookStealer.Properties.Resources", typeof (WebhookStealer.Properties.Resources).Assembly);
        return WebhookStealer.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => WebhookStealer.Properties.Resources.resourceCulture;
      set => WebhookStealer.Properties.Resources.resourceCulture = value;
    }

    internal static string Code => WebhookStealer.Properties.Resources.ResourceManager.GetString(nameof (Code), WebhookStealer.Properties.Resources.resourceCulture);

    internal static Bitmap photo => (Bitmap) WebhookStealer.Properties.Resources.ResourceManager.GetObject(nameof (photo), WebhookStealer.Properties.Resources.resourceCulture);
  }
}
