using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Numerics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MSP_Clicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // кол-во очков.
        BigInteger score = new BigInteger(0);
        // уровень умений.
        BigInteger skill = new BigInteger(1);
        // порог.
        BigInteger target = new BigInteger(10);
        // цена за 5 очков скилла.
        BigInteger skillPrice = new BigInteger(10000);


        public MainPage()
        {
            this.InitializeComponent();
            // выводим кол-во очков.
            scoreValue.Text = score.ToString();
            // выводим скилл.
            skillValue.Text = skill.ToString();
            // выводим цену.
            skillPriceText.Text = skillPrice.ToString();
            // блокируем кнопку.
            buySkills.IsEnabled = false;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // если мы переступили порог, то...
            if (score >= target)
            {
                // увеличиваем скилл на 1.
                skill = BigInteger.Add(skill, 1);
                // поднимаем порог. 
                target = BigInteger.Multiply(target, 2);
            }

            // обновляем значение очков.
            score = BigInteger.Add(score, skill);
            // обновляем кол-во очков.
            scoreValue.Text = score.ToString();
            // обновляем скилл.
            skillValue.Text = skill.ToString();
            // обновляем  цену.
            skillPriceText.Text = skillPrice.ToString();

            if (score >= skillPrice) buySkills.IsEnabled = true;
        }

        private void buySkills_Click(object sender, RoutedEventArgs e)
        {
            // если нам хватает очков, то...
            if (score >= skillPrice)
            {
                // вычитаем очки.
                score = BigInteger.Subtract(score, skillPrice);
                // зачисляем скиллы.
                skill = BigInteger.Add(skill, 5);
                // увеличиваем цену.
                skillPrice = BigInteger.Multiply(skillPrice, 5000);
                // обновляем кол-во очков.
                scoreValue.Text = score.ToString();
                // обновляем скилл.
                skillValue.Text = skill.ToString();
                // обновляем цену.
                skillPriceText.Text = skillPrice.ToString();
                // блокируем кнопку. 
                buySkills.IsEnabled = false;
            }
        }
    }
}
