
#include "bindings.h"
#if defined(__i386__)
#include "registrar-i386.h"
#elif defined(__x86_64__)
#include "registrar-x86_64.h"
#elif defined(__arm__)
#include "registrar-arm32.h" // this includes all 32-bit arm architectures.
#elif defined(__aarch64__)
#include "registrar-arm64.h"
#else
#error Unknown architecture
#endif
