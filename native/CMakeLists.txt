cmake_minimum_required(VERSION 3.10)
set(TARGET Yaz0)
project(${TARGET} VERSION 0.1.0)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)
set(CMAKE_POSITION_INDEPENDENT_CODE ON)
set(CMAKE_SHARED_LIBRARY_PREFIX "")

if("${CMAKE_CXX_COMPILER_ID}" STREQUAL "GNU")
    add_compile_options(-fdiagnostics-color=always)

    if(WIN32)
        set(CMAKE_CXX_STANDARD_LIBRARIES "-static -static-libgcc -static-libstdc++")
    endif()
elseif("${CMAKE_CXX_COMPILER_ID}" STREQUAL "Clang")
    add_compile_options(-fcolor-diagnostics)
endif()

add_library(${TARGET} SHARED
    ./src/include/cs_yaz0.h
    ./src/cs_yaz0.cpp
)

if(MSVC)
    target_compile_options(${TARGET} PRIVATE /W4 /wd4244 /wd4127 /Zc:__cplusplus)
else()
    target_compile_options(${TARGET} PRIVATE -Wall -Wextra -fno-plt)
endif()

add_subdirectory(${CMAKE_CURRENT_SOURCE_DIR}/lib/syaz0)
target_link_libraries(${TARGET} PRIVATE syaz0)

target_include_directories(${TARGET} PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/src/include)

set(CPACK_PROJECT_NAME ${PROJECT_NAME})
set(CPACK_PROJECT_VERSION ${PROJECT_VERSION})
include(CPack)
