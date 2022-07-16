using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace aws_sqs_api
{
    public class WeatherForecastProcessor : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Starting Background Processor");
            var credentials = new BasicAWSCredentials("AccesKey", "SecretKey");
            var client = new AmazonSQSClient(credentials, RegionEndpoint.USEast2);
            while (!stoppingToken.IsCancellationRequested)
            {
                var request = new ReceiveMessageRequest()
                {
                    QueueUrl = "Url"

                };
                var response = await client.ReceiveMessageAsync(request);
                foreach (var messages in response.Messages)
                {
                    Console.WriteLine(messages.Body);
                }
            }
        }
    }
}
