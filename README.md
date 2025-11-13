# CanaryDeploymentTest

## Descrição do cenário

Este repositório simula a publicação de uma aplicação em substituição a outra. Os projetos são:

1. Projeto **Old** (`LoadBalancerTest/OldApp`): Possui dois endpoints, `/Main` e `/Second` e está publicado na rota `api/balance/old/v1/[controller]`. Representa um serviço em produção. Seus arquivos de publicação no K8S estão em `k8s/old`. Escrito em C#/.NET.
2. Projeto **NewApp** (`LoadBalancerTest/NewApp`): Possui apenas o endpoint `/Main` para substituir o `old/v1/Main`. Está publicado na rota `api/balance/new/v1/Main`. Seus arquivos de publicação no K8S estão em `k8s/new`. Escrito em C#/.NET.
3. Projeto **NewSecondApp** (`LoadBalancerTest/NewSecondApp`): Possui apenas o endpoint `/Second` para substituir o `old/v1/Second`. Está publicado na rota `api/balance/new-second/v1/Second`. Seus arquivos de publicação no K8S estão em `k8s/new_second`. Escrito em C#/.NET.

Diante disso, a necesside é:

> Substituir o serviço Old com o NewApp e NewSecondApp, cada um com seu respectivo endpoint. O processo de substituição deve poder ser gradual e as rotas serem reescritas. A implementação deve ter o menor esforço possível em desenvolvimento. Os serviços estão em Cluster do K8S gerenciado em uma VM, não como serviço de cloud.

## Detalhes do processo

Durante a investigação, algumas soluções foram tentadas, mas esbarram em limitações de execução ou complexidade de implementação:

1. Combinar `canary` com `rewrite` dentro dos arquivos de configuração do `Ingress`. O `rewrite` é ignorado e o serviço novo recebe a rota antiga. Isso faz com que seja necessário alterar o código do serviço de destino (NewApp e NewSecondApp), criando um middleware que transforme a rota.
2. O `canary` permite redirecionar para vários serviços diferentes. Ele irá sempre redirecionar para o primeiro informado nas rotas.
3. Implementar `istio` ou alguma ferramenta semelhante exigem permissões especiais e a configuração da reescrita das rotas não costumam ser simples.

## Solução

Foi realizada a criação de um proxy reverso usando YARP, implementado em `LoadBalancerTest/BalanceGateway` combinado com a configuração do `canary`, em `k8s/gateway/ingress.yaml`. A configuração das rotas fica no `appsettings.json` e o serviço consome pouco recurso. Os deployments ou ingresses dos outros serviços ficam inalterados, apenas os dados da nova publicação.