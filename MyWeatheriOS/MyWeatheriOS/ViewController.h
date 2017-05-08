//
//  ViewController.h
//  MyWeatheriOS
//
//  Created by Xamarin on 5/8/17.
//  Copyright © 2017 Xamarin. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ViewController : UIViewController
@property (weak, nonatomic) IBOutlet UILabel *LabelDetails;

@property (weak, nonatomic) IBOutlet UILabel *LabelWeather;
@property (weak, nonatomic) IBOutlet UITextField *TextFieldCity;
@property (weak, nonatomic) IBOutlet UITextField *TextFieldState;
@property (strong, nonatomic) IBOutlet UIView *MainView;
- (IBAction)GetWeatherClick:(id)sender;

@end

