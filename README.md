# Inventory Management System (Система менеджмента продукции)
CRM-система, разработанная на платформе .NET6 с использованием следующего стака:
<ul>
  <li>Blazor Server</li>
  <li>Entity Framework 6</li>
  <li>Microsoft SQL Server</li>
  <li>Frontend framework Radzen</li>
  <li>MS Identity</li>
  <li>Docker</li>
</ul>

Приложение контейнеризовано через Docker-compose</br>
Репозиторий с образом на <a href="https://hub.docker.com/u/vladimirk2003">Docker Hub</a></br>
В решении применён подход чистой архитектуры. Каждый проект - отдельный её слой:</br>
<ul>
  <li><b>IMS.CoreBusiness</b> - базовые сущности которыми оперирует система. Продукт, единица комплектующих, их транзакции. Помимо этого внедрена логика валидации. </li>
  <li><b>IMS.PluginsEFCore</b> - классы-репозитории в которых реализована логика взаимодействия сущностей в проекте, а так же контекст базы данных.</li>
  <li><b>IMS.UseCases</b> - </li>
</ul>

![](https://64.media.tumblr.com/e02a94eb3ed476b9088dae2247218b35/tumblr_pof1ooiEIG1x6a7yto1_500.gif)
