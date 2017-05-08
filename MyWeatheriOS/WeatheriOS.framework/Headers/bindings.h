#include "embeddinator.h"
#import <Foundation/Foundation.h>


#if !__has_feature(objc_arc)
#error Embeddinator code must be built with ARC.
#endif

// forward declarations
@class XAMWeatherFetcher;
@class XAMWeatherResult;


NS_ASSUME_NONNULL_BEGIN


/** Class XAMWeatherFetcher
 *  Corresponding .NET Qualified Name: `XAMWeatherFetcher, WeatheriOS, Version=1.0.6337.22019, Culture=neutral, PublicKeyToken=null`
 */
@interface XAMWeatherFetcher : NSObject {
	// This field is not meant to be accessed from user code
	@public MonoEmbedObject* _object;
}

- (nullable instancetype)initWithCity:(NSString *)city state:(NSString *)state;

/** This type is not meant to be created using only default values
 *  Both the `-init` and `+new` selectors cannot be used to create instances of this type.
 */
- (nullable instancetype)init NS_UNAVAILABLE;
+ (nullable instancetype)new NS_UNAVAILABLE;


@property (nonatomic, readonly) NSString *city;
@property (nonatomic, readonly) NSString *state;

- (XAMWeatherResult*)getWeather;
/** This selector is not meant to be called from user code
 *  It exists solely to allow the correct subclassing of managed (.net) types
 */
- (nullable instancetype)initForSuper;

@end


/** Class XAMWeatherResult
 *  Corresponding .NET Qualified Name: `XAMWeatherResult, WeatheriOS, Version=1.0.6337.22019, Culture=neutral, PublicKeyToken=null`
 */
@interface XAMWeatherResult : NSObject {
	// This field is not meant to be accessed from user code
	@public MonoEmbedObject* _object;
}

- (nullable instancetype)initWithTemp:(NSString *)temp text:(NSString *)text;

/** This type is not meant to be created using only default values
 *  Both the `-init` and `+new` selectors cannot be used to create instances of this type.
 */
- (nullable instancetype)init NS_UNAVAILABLE;
+ (nullable instancetype)new NS_UNAVAILABLE;


@property (nonatomic, readonly) NSString *temp;
@property (nonatomic, readonly) NSString *text;

/** This selector is not meant to be called from user code
 *  It exists solely to allow the correct subclassing of managed (.net) types
 */
- (nullable instancetype)initForSuper;

@end

NS_ASSUME_NONNULL_END

