# AzTranslate
AzTranslate is an application to translate your YouTube videos using Azure speech service.

*Note: this solution is not the prettiest solution you will see in terms of design and code. I just made it to overcome a problem I'm facing while transcribing and translating my YouTube videos.*

[![Build Dockerfile and push the image to DockerHub](https://github.com/taqabubaker/AzTranslate/actions/workflows/build-dockerfile.yml/badge.svg?branch=master)](https://github.com/taqabubaker/AzTranslate/actions/workflows/build-dockerfile.yml)

# Deployment
You can click on below **Deploy to Azure** button to deploy the solution to your Azure subscription.

[![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Ftaqabubaker%2FAzTranslate%2Fmaster%2Fazuredeploy.json)
[![Visualize](https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/visualizebutton.svg?sanitize=true)](http://armviz.io/#/?load=https%3A%2F%2Fraw.githubusercontent.com%2Ftaqabubaker%2FAzTranslate%2Fmaster%2Fazuredeploy.json)

after the deployment successfuly get deployed go to the **Cognitive Services - Speech** service and click on the **Keys and EndPoint** and copy **KEY 1**.

![Speech Service](/docs/images/1.jpg)
![Keys and EndPoint](/docs/images/2.jpg)
![KEY 1](/docs/images/3.jpg)

Then go to the **App Service** and click on the **Deployment Center**

![App Service](/docs/images/4.jpg)
![Deployment Center](/docs/images/5.jpg)

In the **Deployment Center** click on **Settings** and append the **KEY 1** you copied previously into **Startup File**. Your **Startup File** should look something similar to this:

`-e AzureSpeechTranslation:Region=[your-resource-group-region] -e AzureSpeechTranslation:SubscriptionKey=[xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx]`

where `[your-resource-group-region]` is the region of the resource group holding the solution's resources. This will be filled automatically for you during the deployment.

and `[xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx]` is the **KEY 1** you copied from the **Cognitive Services - Speech**.

Click on **Save** and then on the **Browse** button.

![Startup File](/docs/images/6.jpg)
