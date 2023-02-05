﻿
using Amazon.S3;
using Amazon.S3.Model;

var s3Client = new AmazonS3Client();

// await using var inputStream = new FileStream("./face.jpg", FileMode.Open, FileAccess.Read);
await using var inputStream = new FileStream("./movies.csv", FileMode.Open, FileAccess.Read);
    
/*var putObjectRequest = new PutObjectRequest
{
    BucketName    = "ske-aws-try",
    Key = "images/face.jpg",
    ContentType = "image/jpeg",
    InputStream = inputStream
};*/

var putObjectRequest = new PutObjectRequest
{
    BucketName    = "ske-aws-try",
    Key = "files/movies.csv",
    ContentType = "text/csv",
    InputStream = inputStream
};

await s3Client.PutObjectAsync(putObjectRequest);