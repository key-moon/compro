// detail: https://atcoder.jp/contests/abc121/submissions/20192467
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using namespace std;

int main() {
	int H, W;
	int h, w;
	cin >> H >> W >> h >> w;
	cout << H * W - H * w - h * W + h * w << endl;
}
