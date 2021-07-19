using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatajeMedia
{
    public class Fms
    {
        // Solução para deixar os forms como objetos e chama-los quando precisar
        //public static string nmain = "FrCtl";
        public static FrCtl oFrCtl; // o primeiro form instanciado como objeto no aplicativo tem que ser referenciado no construtor
        public static FrPlay oFrPlay;
        public static FrVideoAdjusts oFrVideoAdjusts = new FrVideoAdjusts();

        public static void hdestroy(object sender, EventArgs ee)
        {
            typeof(Fms).GetFields().ToList().ForEach(m =>
            {
                if (m.FieldType.Name == sender.GetType().Name)
                {
                    sender = Activator.CreateInstance(m.FieldType, true);
                    m.SetValue(null, sender); // sempre usar SetValue senão o endereço da classe declarada perde a referencia
                    // adicionar handle recursivamente quando fechar
                    sender.GetType().GetMethod("add_HandleDestroyed").Invoke(sender, new object[] { new EventHandler(Fms.hdestroy) });
                }
            });
        }

        public static System.Windows.Forms.Form getmain<T>()
        {
            System.Windows.Forms.Form fm = (System.Windows.Forms.Form)Activator.CreateInstance(typeof(T), true);
            return getmain(fm);
        }
        public static System.Windows.Forms.Form getmain(System.Windows.Forms.Form fm)
        {
            typeof(Fms).GetFields().ToList().ForEach(f =>
            {
                if (f.FieldType.Name == fm.GetType().Name)
                {
                    f.SetValue(null, fm); // Para o form Main apenas seta no form do mesmo tipo que foi declarado no Fms
                }
                else // Para os outros cria a instancia e adiciona rotina no evento HandleDestroyed que recriar instancia logo após ser descartado
                {
                    var o = f.GetValue(null); // obter objeto do field
                    o = Activator.CreateInstance(f.FieldType, true); // Criar instancia (equivalente 'New ...()')
                    if (o.GetType().BaseType.Name == "Form")
                    {
                        f.SetValue(null, o);
                        o.GetType().GetMethod("add_HandleDestroyed").Invoke(o, new object[] { new EventHandler(Fms.hdestroy) });
                        // .
                        //--- Exemplos de invocar métodos
                        // .
                        //o.GetType().GetMethods().ToList().Where(mt => mt.Name == "Show").First().Invoke(o, new object[] { this });
                        //((Form)o).Show();
                    }
                }
            });

            return fm;
        }

        public class autorun
        {
            public autorun()
            {
                // OBSOLETO: Exemplo de como executar uma rotina na declaração sem ser chamado pelo programa principal
                // oFrPlay.HandleDestroyed += new System.EventHandler((object sender, EventArgs e) => oFrPlay = new FrPlay());
            }
        }       
        private static readonly autorun a = new autorun();

    }
}
