using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using spacetraders.Core;
using spacetraders.Exceptions;
using spacetraders.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Timers;
using static spacetraders.Http.Enum;

namespace spacetraders.Http
{
    public class ToSend
    {
        public Request req;
        public bool Sent;
        public string resp = "";

        public ToSend(Request request)
        {
            req = request;
            Sent = false;
        }
    }

    // Holds all requests to do
    public class Pool
    {
        public int Interval;
        public List<ToSend> Queue;
        public int MaxQueueLength;


        public Pool(int interval, int queuesize)
        {
            Interval = interval;
            MaxQueueLength = queuesize;
            Queue = new List<ToSend>(queuesize);
        }

        // Add a Request to the queue, and return the item?
        public async Task<string> AddRequest(Request request)
        {
            Constants.Log.Debug($"[ AddRequest ] Adding request to queue");
            Constants.Log.Debug($"[ AddRequest ] Request is to '{request.url}', with JSON '{request.json}'");
            try
            {
                ToSend ts = new(request);
                Queue.Add(ts);

                Constants.Log.Debug($"[ AddRequest ] Added, waiting for return...");

                //Console.WriteLine($"Added item with URL {request.url} to queue");

                while (!ts.Sent)
                {
                    //Console.WriteLine($"Waiting for request with URL `{request.url}` to be returned. (current: {ts.Sent})");
                    await Task.Delay(Interval / 2);
                }

                //Console.WriteLine("Returning from queue.");
                Constants.Log.Debug($"[ AddRequest ] Returned, returning to caller");

                return ts.resp;
            }
            catch (Exception e)
            {
                Constants.Log.Error($"[ AddRequest ] Request URL '{request.url}' not added to queue: at max. capacity");
                throw new Exception($"[WARN] Request URL `{request.url}` not added to queue: queue is at max capacity!)", e);
            }
        }

        private void _StartSendingRequests()
        {
            while (true)
            {
                if (Queue.Any())
                {
                    // Send the first request from the queue, and set 'resp' to the JSON
                    ToSend r = Queue.First();
                    Queue.Remove(r);
                    
                    Constants.Log.Debug($"[ Pool ] Received item from queue, bound for '{r.req.url}'");
                    Constants.Log.Debug($"[ Pool ] Sending...");
                    
                    r.resp = r.req.run();
                    r.Sent = true;

                    Constants.Log.Debug($"[ Pool ] Done with request bound for '{r.req.url}'");
                }
                
                Task.Delay(Interval).Wait();
            }
        }

        public async Task Start()
        {
            try
            {
                Constants.Log.Debug("Starting function '_StartSendingRequests()'");
                Task t = Task.Run(_StartSendingRequests);
                await t.WaitAsync(new CancellationToken());
            }
            catch (Exception e)
            {
                Constants.Log.Error(e.Message);
                throw e;
            }
        }
    }
    public class Request
    {
        public RequestType type;
        public string url;
        public string json;


        public Request(RequestType Type, string Url, string Json)
        {
            type = Type;
            url = $"{Constants.BaseURL}/{Url}";
            json = Json;
        }

        static string _ErrorString(RestResponse resp)
        {
            string ErrorMessage = $"""
                            NullReferenceException - Details are as follows:
                            ------------------------------------------------
                            Response URI: {resp.ResponseUri}
                            Type:         GET

                            Response:     {resp.Content}
                            ------------------------------------------------

                            Response from the API has been written to `exception.json`
                            """;

            return ErrorMessage;
        }

        public string run()
        {
            RestClient cli = new(url);
            RestRequest req = new();
            string Token = Environment.GetEnvironmentVariable("SPACETRADERS_TOKEN");

            Constants.Log.Debug($"[ RequestSender ] Running request with URL {url}");

            req.AddHeader("Authorization", $"Bearer {Token}");
            req.AddStringBody(json, ContentType.Json);

            switch (type)
            {
                case RequestType.GET:
                    RestResponse resp = cli.ExecuteGet(req);

                    Constants.Log.Debug($"[ RequestSender ] Received response: '{resp.Content}'");

                    JsonNode JSON = JsonObject.Parse(resp.Content)["data"];
                    JsonNode ErrorMaybe = JsonObject.Parse(resp.Content)["error"];

                    // Error checking
                    Constants.Log.Debug($"[ RequestSender ] Checking response for errors...");
                    if (ErrorMaybe != null)
                    {
                        string ErrorMessage = _ErrorString(resp);

                        File.WriteAllText(@"exception.json", resp.Content);
                        throw new APIException(ErrorMessage);
                    }

                    // Workaround for '/v2'
                    else if (JSON == null)
                    {
                        JSON = JsonObject.Parse(resp.Content);
                    }

                    Constants.Log.Debug($"[ RequestSender ] All clear, writing response to 'response.json', parsing as a string, and returning");

                    File.WriteAllText(@"response.json", resp.Content);
                    string JSONString = JSON.ToJsonString();

                    return JSONString;


                case RequestType.POST:
                    resp = cli.ExecutePost(req);

                    Constants.Log.Debug($"[ RequestSender ] Received response: '{resp.Content}'");

                    JSON = JsonObject.Parse(resp.Content)["data"];
                    ErrorMaybe = JsonObject.Parse(resp.Content)["error"];

                    // Error checking
                    Constants.Log.Debug($"[ RequestSender ] Checking response for errors...");
                    if (ErrorMaybe != null)
                    {
                        string ErrorMessage = _ErrorString(resp);

                        File.WriteAllText(@"exception.json", resp.Content);
                        throw new APIException(ErrorMessage);
                    }

                    // Workaround for '/v2'
                    else if (JSON == null)
                    {
                        JSON = JsonObject.Parse(resp.Content);
                    }

                    Constants.Log.Debug($"[ RequestSender ] All clear, writing response to 'response.json', parsing as a string, and returning");

                    File.WriteAllText(@"response.json", resp.Content);
                    JSONString = JSON.ToJsonString();

                    return JSONString;


                case RequestType.PUT:
                    resp = cli.ExecutePut(req);

                    Constants.Log.Debug($"[ RequestSender ] Received response: '{resp.Content}'");

                    JSON = JsonObject.Parse(resp.Content)["data"];
                    ErrorMaybe = JsonObject.Parse(resp.Content)["error"];

                    // Error checking
                    Constants.Log.Debug($"[ RequestSender ] Checking response for errors...");
                    if (ErrorMaybe != null)
                    {
                        string ErrorMessage = _ErrorString(resp);

                        File.WriteAllText(@"exception.json", resp.Content);
                        throw new APIException(ErrorMessage);
                    }

                    // Workaround for '/v2'
                    else if (JSON == null)
                    {
                        JSON = JsonObject.Parse(resp.Content);
                    }

                    Constants.Log.Debug($"[ RequestSender ] All clear, writing response to 'response.json', parsing as a string, and returning");

                    File.WriteAllText(@"response.json", resp.Content);
                    JSONString = JSON.ToJsonString();

                    return JSONString;


                default:
                    return "";
            }
        }
    }
}