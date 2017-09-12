//
//  ViewController.m
//  MyWeatherMac
//
//  Created by Xamarin on 5/8/17.
//  Copyright © 2017 Xamarin. All rights reserved.
//

#import "ViewController.h"
#import "Weather/Weather.h"

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];

    // Do any additional setup after loading the view.
}

- (void)setRepresentedObject:(id)representedObject {
    [super setRepresentedObject:representedObject];

    // Update the view, if already loaded.
}


- (IBAction)GetWeatherClick:(id)sender {
    XAMWeatherFetcher * fetcher = [[XAMWeatherFetcher alloc] initWithCity:_TextFieldCity.stringValue state:_TextFieldState.stringValue];
    
    XAMWeatherResult * result = [fetcher getWeather];
    
    if (result) {
        _LabelDetails.stringValue = [result text];
        _LabelWeather.stringValue = [[result temp] stringByAppendingString:@" °F"];
    }
    // This means the managed API returned null an exception occured.
    else {
        _LabelDetails.stringValue = @"An error ocurred";
        _LabelWeather.stringValue = @" :( ";
    }
}
@end
