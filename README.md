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
  <li><b>IMS.CoreBusiness</b> - Базовые сущности которыми оперирует система. Продукт, единица комплектующих, их транзакции. Помимо этого внедрена логика валидации. </li>
  <li><b>IMS.PluginsEFCore</b> - Связь с БД через Entity Framework. Kлассы-репозитории для взаимодействия с базой данных, имеющие логику запросов к БД, а так же её контекст.</li>
  <li><b>IMS.UseCases</b> - Логика приложения. Слой с классами, реализующими логику определённых ситуаций в приложении и имеющие связь с PluginsEFCore для её обработки. </li>
  <li><b>IMS.WebApp</b> - UI. Страницы, компоненты и модели, с которыми напрямую взаимодействует пользователь.</li>
</ul>
</br>
</br>
Данная CRM-система сделана в качестве курсовой работы на втором курсе обучения в Колледже Информационных Технологий и Строительства в начале 2022 года. Успешно защищена в мае 2022 на комиссии.</br>
![](https://64.media.tumblr.com/e02a94eb3ed476b9088dae2247218b35/tumblr_pof1ooiEIG1x6a7yto1_500.gif)
<img src="https://64.media.tumblr.com/e02a94eb3ed476b9088dae2247218b35/tumblr_pof1ooiEIG1x6a7yto1_500.gif"></img>
