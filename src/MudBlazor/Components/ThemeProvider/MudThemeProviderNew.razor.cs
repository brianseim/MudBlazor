﻿using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using MudColor = System.Drawing.Color;
using System.Text;
using System.Globalization;

namespace MudBlazor
{
    public class BaseMudThemeProviderNew : ComponentBase
    {
        [Parameter] public MudTheme Theme { get; set; }

        protected override void OnInitialized()
        {
            if (Theme == null)
            {
                MudTheme _theme = new DefaultTheme();
                Theme = _theme;
            }
        }

        public string BuildTheme()
        {
            var theme = new StringBuilder();
            theme.AppendLine("<style>");
            theme.Append(":root");
            theme.AppendLine("{");
            GenerateTheme(theme);
            theme.AppendLine("}");
            theme.AppendLine("</style>");
            return theme.ToString();
        }

        private string Breakpoint = "mud-breakpoint";
        private string Palette = "mud-palette";
        private string Elevation = "mud-elevation";
        private string LayoutProperties = "mud";
        private string Zindex = "mud-zindex";

        public static string ColorRgbDarken(string hex)
        {
            MudColor Color = ColorManager.FromHex(hex);
            Color = ColorManager.ColorDarken(Color, 0.075);
            return $"rgb({Color.R},{Color.G},{Color.B})";
        }
        public static string ColorRgbLighten(string hex)
        {
            MudColor Color = ColorManager.FromHex(hex);
            Color = ColorManager.ColorLighten(Color, 0.075);
            return $"rgb({Color.R},{Color.G},{Color.B})";
        }

        public static string ColorRgba(string hex, double alpha)
        {
            MudColor Color = ColorManager.FromHex(hex);
            return $"rgba({Color.R},{Color.G},{Color.B}, {alpha.ToString(CultureInfo.InvariantCulture)})";
        }

        protected virtual void GenerateTheme(StringBuilder theme)
        {
            //Palette
            theme.AppendLine($"--{Palette}-black: {Theme.Palette.Black};");
            theme.AppendLine($"--{Palette}-white: {Theme.Palette.White};");

            theme.AppendLine($"--{Palette}-primary: {Theme.Palette.Primary};");
            theme.AppendLine($"--{Palette}-primary-text: {Colors.Shades.White};");
            theme.AppendLine($"--{Palette}-primary-darken: {ColorRgbDarken(Theme.Palette.Primary)};");
            theme.AppendLine($"--{Palette}-primary-lighten: {ColorRgbLighten(Theme.Palette.Primary)};");
            theme.AppendLine($"--{Palette}-secondary: {Theme.Palette.Secondary};");
            theme.AppendLine($"--{Palette}-secondary-text: {Colors.Shades.White};");
            theme.AppendLine($"--{Palette}-secondary-darken: {ColorRgbDarken(Theme.Palette.Secondary)};");
            theme.AppendLine($"--{Palette}-secondary-lighten: {ColorRgbLighten(Theme.Palette.Secondary)};");
            theme.AppendLine($"--{Palette}-tertiary: {Theme.Palette.Tertiary};");
            theme.AppendLine($"--{Palette}-tertiary-text: {Colors.Shades.White};");
            theme.AppendLine($"--{Palette}-tertiary-darken: {ColorRgbDarken(Theme.Palette.Tertiary)};");
            theme.AppendLine($"--{Palette}-tertiary-lighten: {ColorRgbLighten(Theme.Palette.Tertiary)};");
            theme.AppendLine($"--{Palette}-info: {Theme.Palette.Info};");
            theme.AppendLine($"--{Palette}-info-text: {Colors.Shades.White};");
            theme.AppendLine($"--{Palette}-info-darken: {ColorRgbDarken(Theme.Palette.Info)};");
            theme.AppendLine($"--{Palette}-info-lighten: {ColorRgbLighten(Theme.Palette.Info)};");
            theme.AppendLine($"--{Palette}-success: {Theme.Palette.Success};");
            theme.AppendLine($"--{Palette}-success-text: {Colors.Shades.White};");
            theme.AppendLine($"--{Palette}-success-darken: {ColorRgbDarken(Theme.Palette.Success)};");
            theme.AppendLine($"--{Palette}-success-lighten: {ColorRgbLighten(Theme.Palette.Success)};");
            theme.AppendLine($"--{Palette}-warning: {Theme.Palette.Warning};");
            theme.AppendLine($"--{Palette}-warning-text: {Colors.Shades.White};");
            theme.AppendLine($"--{Palette}-warning-darken: {ColorRgbDarken(Theme.Palette.Warning)};");
            theme.AppendLine($"--{Palette}-warning-lighten: {ColorRgbLighten(Theme.Palette.Warning)};");
            theme.AppendLine($"--{Palette}-error: {Theme.Palette.Error};");
            theme.AppendLine($"--{Palette}-error-text: {Colors.Shades.White};");
            theme.AppendLine($"--{Palette}-error-darken: {ColorRgbDarken(Theme.Palette.Error)};");
            theme.AppendLine($"--{Palette}-error-lighten: {ColorRgbLighten(Theme.Palette.Error)};");
            theme.AppendLine($"--{Palette}-dark: {Theme.Palette.Dark};");
            theme.AppendLine($"--{Palette}-dark-text: {Colors.Shades.White};");
            theme.AppendLine($"--{Palette}-dark-darken: {ColorRgbDarken(Theme.Palette.Dark)};");
            theme.AppendLine($"--{Palette}-dark-lighten: {ColorRgbLighten(Theme.Palette.Dark)};");

            theme.AppendLine($"--{Palette}-text-primary: {Theme.Palette.TextPrimary};");
            theme.AppendLine($"--{Palette}-text-secondary: {Theme.Palette.TextSecondary};");
            theme.AppendLine($"--{Palette}-text-disabled: {Theme.Palette.TextDisabled};");

            theme.AppendLine($"--{Palette}-action-default: {Theme.Palette.ActionDefault};");
            theme.AppendLine($"--{Palette}-action-default-hover: {ColorRgba(Colors.Shades.Black, Theme.Palette.HoverOpacity)};");
            theme.AppendLine($"--{Palette}-action-disabled: {Theme.Palette.ActionDisabled};");
            theme.AppendLine($"--{Palette}-action-disabled-background: {Theme.Palette.ActionDisabledBackground};");

            theme.AppendLine($"--{Palette}-background: {Theme.Palette.Background};");
            theme.AppendLine($"--{Palette}-surface: {Theme.Palette.Surface};");
            theme.AppendLine($"--{Palette}-drawer-background: {Theme.Palette.DrawerBackground};");
            theme.AppendLine($"--{Palette}-drawer-text: {Theme.Palette.DrawerText};");
            theme.AppendLine($"--{Palette}-appbar-background: {Theme.Palette.AppbarBackground};");
            theme.AppendLine($"--{Palette}-appbar-text: {Theme.Palette.AppbarText};");

            theme.AppendLine($"--{Palette}-lines-default: {Theme.Palette.LinesDefault};");
            theme.AppendLine($"--{Palette}-lines-inputs: {Theme.Palette.LinesInputs};");

            theme.AppendLine($"--{Palette}-divider: {Theme.Palette.Divider};");
            theme.AppendLine($"--{Palette}-divider-light: {Theme.Palette.DividerLight};");

            //Elevations
            theme.AppendLine($"--{Elevation}-0: {Theme.Shadow.Elevation.GetValue(0)};");
            theme.AppendLine($"--{Elevation}-1: {Theme.Shadow.Elevation.GetValue(1)};");
            theme.AppendLine($"--{Elevation}-2: {Theme.Shadow.Elevation.GetValue(2)};");
            theme.AppendLine($"--{Elevation}-3: {Theme.Shadow.Elevation.GetValue(3)};");
            theme.AppendLine($"--{Elevation}-4: {Theme.Shadow.Elevation.GetValue(4)};");
            theme.AppendLine($"--{Elevation}-5: {Theme.Shadow.Elevation.GetValue(5)};");
            theme.AppendLine($"--{Elevation}-6: {Theme.Shadow.Elevation.GetValue(6)};");
            theme.AppendLine($"--{Elevation}-7: {Theme.Shadow.Elevation.GetValue(7)};");
            theme.AppendLine($"--{Elevation}-8: {Theme.Shadow.Elevation.GetValue(8)};");
            theme.AppendLine($"--{Elevation}-9: {Theme.Shadow.Elevation.GetValue(9)};");
            theme.AppendLine($"--{Elevation}-10: {Theme.Shadow.Elevation.GetValue(10)};");
            theme.AppendLine($"--{Elevation}-11: {Theme.Shadow.Elevation.GetValue(11)};");
            theme.AppendLine($"--{Elevation}-12: {Theme.Shadow.Elevation.GetValue(12)};");
            theme.AppendLine($"--{Elevation}-13: {Theme.Shadow.Elevation.GetValue(13)};");
            theme.AppendLine($"--{Elevation}-14: {Theme.Shadow.Elevation.GetValue(14)};");
            theme.AppendLine($"--{Elevation}-15: {Theme.Shadow.Elevation.GetValue(15)};");
            theme.AppendLine($"--{Elevation}-16: {Theme.Shadow.Elevation.GetValue(16)};");
            theme.AppendLine($"--{Elevation}-17: {Theme.Shadow.Elevation.GetValue(17)};");
            theme.AppendLine($"--{Elevation}-18: {Theme.Shadow.Elevation.GetValue(18)};");
            theme.AppendLine($"--{Elevation}-19: {Theme.Shadow.Elevation.GetValue(19)};");
            theme.AppendLine($"--{Elevation}-20: {Theme.Shadow.Elevation.GetValue(20)};");
            theme.AppendLine($"--{Elevation}-21: {Theme.Shadow.Elevation.GetValue(21)};");
            theme.AppendLine($"--{Elevation}-22: {Theme.Shadow.Elevation.GetValue(22)};");
            theme.AppendLine($"--{Elevation}-23: {Theme.Shadow.Elevation.GetValue(23)};");
            theme.AppendLine($"--{Elevation}-24: {Theme.Shadow.Elevation.GetValue(24)};");
            theme.AppendLine($"--{Elevation}-25: {Theme.Shadow.Elevation.GetValue(25)};");

            //Layout Properties
            theme.AppendLine($"--{LayoutProperties}-default-borderradius: {Theme.LayoutProperties.DefaultBorderRadius};");
            theme.AppendLine($"--{LayoutProperties}-drawer-width: {Theme.LayoutProperties.DrawerWidth};");
            theme.AppendLine($"--{LayoutProperties}-appbar-min-height: {Theme.LayoutProperties.AppbarMinHeight};");

            //Breakpoint
            theme.AppendLine($"--{Breakpoint}-xs: {Theme.Breakpoints.xs};");
            theme.AppendLine($"--{Breakpoint}-sm: {Theme.Breakpoints.sm};");
            theme.AppendLine($"--{Breakpoint}-md: {Theme.Breakpoints.md};");
            theme.AppendLine($"--{Breakpoint}-lg: {Theme.Breakpoints.lg};");
            theme.AppendLine($"--{Breakpoint}-xl: {Theme.Breakpoints.xl};");

            //Z-Index
            theme.AppendLine($"--{Zindex}-drawer: {Theme.ZIndex.Drawer};");
            theme.AppendLine($"--{Zindex}-appbar: {Theme.ZIndex.AppBar};");
            theme.AppendLine($"--{Zindex}-dialog: {Theme.ZIndex.Dialog};");
            theme.AppendLine($"--{Zindex}-popover: {Theme.ZIndex.Popover};");
            theme.AppendLine($"--{Zindex}-snackbar: {Theme.ZIndex.Snackbar};");
            theme.AppendLine($"--{Zindex}-tooltip: {Theme.ZIndex.Tooltip};");
        }
    }
}