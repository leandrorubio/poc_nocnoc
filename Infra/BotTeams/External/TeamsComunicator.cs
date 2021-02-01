using Domain.Adapters;
using System.Threading.Tasks;
using Flurl.Http;
using Domain.Entities;
using System.Collections.Generic;

namespace Infra.BotTeams.External
{
    public class TeamsComunicator : ITeamsComunicator
    {
        public async Task SendMessage(string userName, string type, string urlPopWiki)
        {
            var url = "https://xpcorretora.webhook.office.com/webhookb2/f9542fd8-4a2b-4514-9c6d-98cacd85dcff@cf56e405-d2b0-4266-b210-aa04636b6161/IncomingWebhook/78593bcb1aa8443e9c253451c18e1400/5483bca0-2441-49f3-8c9e-fcaf046b4dbd";

            BotMessagePayload payloadTeste = new BotMessagePayload();

            payloadTeste.PotentialAction = new List<BotMessageAction>
            {
                new BotMessageAction
                {
                    Name = "Visualizar incidente",
                    Target = new List<BotMessageTarget>
                    {
                        new BotMessageTarget
                        {
                            OS = "default",
                            Uri = "https://dev60115.service-now.com/nav_to.do?uri=%2Fchange_request.do%3Fsys_id%3D6a39ce19db0620109bbde04a48961993%26sysparm_stack%3D%26sysparm_view%3D"
                        }
                    }
                },
                new BotMessageAction
                {
                    Name ="Visualizar POP",
                    Target = new List<BotMessageTarget>
                    {
                        new BotMessageTarget
                        {
                            OS = "default",
                            Uri = urlPopWiki
                        }
                    }
                }
            };

            payloadTeste.Sections = new List<BotMessageSection>
            {
                new BotMessageSection
                {
                    Text = "Fala pessoal, poderiam avaliar o seguinte alerta. 😉 </br> <img src='https://i.imgur.com/VDiCIN4.gif'></img>",
                    Facts = new List<BotMessageFact>
                    {
                        new BotMessageFact
                        {
                            Name = "Tipo de Alerta:",
                            Value = type
                        },
                        new BotMessageFact
                        {
                            Name = "Alerta:",
                            Value = "Não ocorreu a liquidação de Tesouro Direto da marca XP"
                        },
                        new BotMessageFact
                        {
                            Name = "Aplicação:",
                            Value = "Corporate.NationalTreasury.Position.Service"
                        },
                        new BotMessageFact
                        {
                            Name = "Responsável pela última publicação:",
                            Value = userName
                        }
                    }
                }
            };

            var request = await url.AllowHttpStatus("400-499, 200-299")
                                   .WithHeader("Accept", "application/json")
                                   .PostJsonAsync(payloadTeste);
        }

        private object payload()
        {
            object payloadObject = new
            {
                @context = "https://schema.org/extensions",
                @type = "MessageCard",
                potentialAction = new[]
                {
                    new {
                        @type = "OpenUri",
                        name = "Visualizar incidente",
                        targets = new[]
                        {
                            new
                            {
                                os= "default",
                                uri = "https://dev60115.service-now.com/nav_to.do?uri=%2Fchange_request.do%3Fsys_id%3D6a39ce19db0620109bbde04a48961993%26sysparm_stack%3D%26sysparm_view%3D"
                            }
                        }
                    },
                    new{
                     @type = "OpenUri",
                        name = "Visualizar POP",
                        targets = new[]
                        {
                            new
                            {
                                os= "default",
                                uri = "https://xpinvestimentos.visualstudio.com/Projetos/_wiki/wikis/Projetos.wiki/3582/Processo-de-Liquida%C3%A7%C3%A3o-do-Tesouro-Direto"
                            }
                        }
                    }
                },
                sections = new[]
                {
                    new {
                        facts = new[]
                        {
                            new
                            {
                                name = "Tipo de Alerta:",
                                value = "P2"
                            },
                            new
                            {
                                name = "Alerta:",
                                value = "Não ocorreu a liquidação de Tesouro Direto da marca XP"
                            },
                            new
                            {
                                name = "Aplicação:",
                                value = "Corporate.NationalTreasury.Position.Service"
                            },
                            new
                            {
                                name = "Responsável pela última publicação:",
                                value = "Caique Gusmão"
                            }
                        },
                        text = "Fala pessoal, poderiam avaliar o seguinte alerta. 😉 </br> <img src='https://i.imgur.com/VDiCIN4.gif'></img>"
                    }
                },
                summary = "(Noc noc ✊✊🚪) Tem um alerta aqui para vocês ...",
                themeColor = "FF0303",
                title = "✊✊🚪 - Tem um alerta aqui para vocês ..."

            };

            return payloadObject;
        }

    }
}