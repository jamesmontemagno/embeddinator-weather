//
//  ViewController.h
//  MyWeatherMac
//
//  Created by Xamarin on 5/8/17.
//  Copyright © 2017 Xamarin. All rights reserved.
//

#import <Cocoa/Cocoa.h>

@interface ViewController : NSViewController

@property (weak) IBOutlet NSTextField *TextFieldCity;
@property (weak) IBOutlet NSTextField *TextFieldState;
@property (weak) IBOutlet NSTextField *LabelWeather;
- (IBAction)GetWeatherClick:(id)sender;
@property (weak) IBOutlet NSTextField *LabelDetails;

@end

