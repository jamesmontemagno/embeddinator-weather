//
//  ViewController.m
//  MyWeatheriOS
//
//  Created by Xamarin on 5/8/17.
//  Copyright © 2017 Xamarin. All rights reserved.
//

#import "ViewController.h"
#include "WeatheriOS/WeatheriOS.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
    
    
    
    [self.view.subviews makeObjectsPerformSelector: @selector(removeFromSuperview)];
    
    WeatherView *view = [[WeatherView alloc] init];
    view.frame = CGRectMake(0, 60, self.view.bounds.size.width, self.view.bounds.size.height - 60);
    [self.view addSubview: view];
}


- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}


- (IBAction)GetWeatherClick:(id)sender {
    
    XAMWeatherFetcher * fetcher = [[XAMWeatherFetcher alloc] initWithCity:_TextFieldCity.text state:_TextFieldState.text];
    
    XAMWeatherResult * result = [fetcher getWeather];
    
    if (result) {
        _LabelDetails.text = [result text];
        _LabelWeather.text = [[result temp] stringByAppendingString:@" °F"];
    }
    // This means the managed API returned null an exception occured.
    else {
        _LabelDetails.text = @"An error ocurred";
        _LabelWeather.text = @" :( ";
    }
    
}
@end
