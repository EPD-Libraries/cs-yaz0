#include "cs_yaz0.h"

#include <yaz0.h>

std::vector<u8>* Compress(u8* src, u32 src_len, u32 alignment, int level) {
  return new auto(syaz0::Compress({src, src_len}, alignment, level));
}