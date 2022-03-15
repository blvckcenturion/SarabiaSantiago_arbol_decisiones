using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SantiagoSarabia_Practice4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public delegate bool Delegate(int weight, string text, bool conclusion);
    public partial class MainWindow : Window
    {
        Tree tr = new Tree();
        Delegate delegateToShow;

        public MainWindow()
        {
            InitializeComponent();
            delegateToShow += VisualizeQuestion;
            // 1st Level
            tr.insert("La empresa me pagara acorde a los estandares para alguien con mi capacidad y experiencia", 400);
            // 2nd Level
            tr.insert("La empresa en cuestion tiene un ambiente laboral bastante agradabe y productivo", 200);
            tr.insert("La empresa en cuestion tiene mucho potencial de crecimiento", 800);
            // 3rd Level
            tr.insert("La empresa en cuestion tiende a tratar a sus empleados de una buena forma y sin explotarlos demasiado", 100);
            tr.insert("La empresa cuenta con muy buenos beneficios laborales", 300);
            tr.insert("La empresa me da opcion a pagos con acciones de la empresa, las cuales podrian apreciarse bastante en un mediano-corto plazo", 700);
            tr.insert("La empresa me brinda una oferta en la cual pobre elevar mis conocimientos, mi experiencia y expectativas salariales de forma exponencial", 900);
            // 4th Level
            tr.insert("ACEPTAR OFERTA", 50);
            tr.insert("RECHAZAR OFERTA", 150);
            tr.insert("ACEPTAR OFERTA", 250);
            tr.insert("RECHAZAR OFERTA", 350);
            tr.insert("ACEPTAR OFERTA", 650);
            tr.insert("RECHAZAR OFERTA", 750);
            tr.insert("ACEPTAR OFERTA", 850);
            tr.insert("RECHAZAR OFERTA", 950);

            Visualize();

        }
        public bool VisualizeQuestion(int weight, string text, bool conclusion)
        {
            if (conclusion)
            {
                MessageBox.Show(text);
                return false;
            } else
            {
                return Microsoft.VisualBasic.Interaction.InputBox(text, "Responda con un Si o No a las preguntas").ToLower() == "si" ? true : false;
            }
        }


        void Visualize()
        {
            List<Node> nodesInOrder = tr.showListInOrder();
            list.Items.Clear();
            foreach (Node node in nodesInOrder)
            {
                list.Items.Add("Elemento:" + node.element + "|| Peso: " + node.number);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tr.Quiz(delegateToShow);
        }

    }
}
